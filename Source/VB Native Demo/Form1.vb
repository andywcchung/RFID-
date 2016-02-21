Imports System
Imports System.IO
Imports System.Threading
Imports CSLibrary
Imports CSLibrary.Constants

Public Class Form1

    Public ReaderCE As HighLevelInterface = New HighLevelInterface

    Private RFIDdata As String = ""

    ' the response data from the reader
    Private readerResponse As String

    Private Delegate Sub DelAddItem()
    Private del As DelAddItem

    'count the program time
    Public Sub ReaderCE_MyRunningStateEvent(ByVal sender As Object, ByVal e As CSLibrary.Events.OnStateChangedEventArgs)
        readerResponse = String.Format("Reader State : {0}", e.state)
    End Sub

    Public Sub ReaderCE_MyInventoryEvent(ByVal sender As Object, ByVal e As CSLibrary.Events.OnAsyncCallbackEventArgs)
        RFIDdata = e.info.epc.ToString & "," & e.info.rssi.ToString & Environment.NewLine

        Dim tmr As Integer = 0
        del = New DelAddItem(AddressOf DelegateWork)
        Dim Result As IAsyncResult
        Result = dataBox.BeginInvoke(del)
        tmr = Environment.TickCount()
        While (Not Result.IsCompleted And Environment.TickCount() > tmr < 3000)
            Application.DoEvents()
        End While

        If (Environment.TickCount - tmr > 3000) Then
            MessageBox.Show("Update Timeout!")
        End If


    End Sub

    Private Sub startRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startRead.Click
        RFIDdata = ""
        dataBox.Text = ""
        AddHandler ReaderCE.OnAsyncCallback, AddressOf Me.ReaderCE_MyInventoryEvent
        AddHandler ReaderCE.OnStateChanged, AddressOf Me.ReaderCE_MyRunningStateEvent
        ReaderCE.SetDynamicQParms(5, 0, 15, 0, 10, 1)
        ReaderCE.SetOperationMode(RadioOperationMode.CONTINUOUS)
        ReaderCE.Options.TagInventory.flags = CSLibrary.Constants.SelectFlags.ZERO
        ReaderCE.StartOperation(Operation.TAG_INVENTORY, False)
        'Timer1.Enabled = True
        startRead.Enabled = False
        stp.Enabled = True
    End Sub

    Private Sub stp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stp.Click

        'remove all callback event

        If (ReaderCE.State <> CSLibrary.Constants.RFState.BUSY) Then
            Return
        End If

        ReaderCE.StopOperation(True)

        While (ReaderCE.State <> CSLibrary.Constants.RFState.IDLE)
            Thread.Sleep(1000)
        End While

        RemoveHandler ReaderCE.OnAsyncCallback, AddressOf Me.ReaderCE_MyInventoryEvent
        RemoveHandler ReaderCE.OnStateChanged, AddressOf Me.ReaderCE_MyRunningStateEvent
        stp.Enabled = False
        startRead.Enabled = True
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DelegateWork()
        dataBox.Text = dataBox.Text & RFIDdata
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As Result

        If Button1.Text = "Connect" Then
            a = ReaderCE.Connect(TextBox_IP.Text, 3000)

            If (a <> CSLibrary.Constants.Result.OK) Then
                MessageBox.Show("Startup CSL Reader Fail")
                MessageBox.Show(a.ToString())
            Else
                MessageBox.Show("CSL Reader Connected")
                Button1.Text = "Disconnect"
                startRead.Enabled = True
            End If
        Else
            stp_Click(sender, System.EventArgs.Empty)

            startRead.Enabled = False
            ReaderCE.Disconnect()
            Button1.Text = "Connect"
        End If
    End Sub
End Class
