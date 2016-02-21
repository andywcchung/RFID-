<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.stp = New System.Windows.Forms.Button
        Me.startRead = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.dataBox = New System.Windows.Forms.TextBox
        Me.TextBox_IP = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'stp
        '
        Me.stp.Enabled = False
        Me.stp.Location = New System.Drawing.Point(240, 287)
        Me.stp.Name = "stp"
        Me.stp.Size = New System.Drawing.Size(103, 27)
        Me.stp.TabIndex = 10
        Me.stp.Text = "Stop Read"
        '
        'startRead
        '
        Me.startRead.Enabled = False
        Me.startRead.Location = New System.Drawing.Point(240, 254)
        Me.startRead.Name = "startRead"
        Me.startRead.Size = New System.Drawing.Size(103, 27)
        Me.startRead.TabIndex = 9
        Me.startRead.Text = "Start Read"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Tag Read"
        '
        'dataBox
        '
        Me.dataBox.Location = New System.Drawing.Point(12, 66)
        Me.dataBox.Multiline = True
        Me.dataBox.Name = "dataBox"
        Me.dataBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dataBox.Size = New System.Drawing.Size(222, 251)
        Me.dataBox.TabIndex = 8
        '
        'TextBox_IP
        '
        Me.TextBox_IP.Location = New System.Drawing.Point(69, 9)
        Me.TextBox_IP.Name = "TextBox_IP"
        Me.TextBox_IP.Size = New System.Drawing.Size(158, 22)
        Me.TextBox_IP.TabIndex = 12
        Me.TextBox_IP.Text = "192.168.25.208"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Reader IP"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(240, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 22)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Connect"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 326)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox_IP)
        Me.Controls.Add(Me.stp)
        Me.Controls.Add(Me.startRead)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dataBox)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stp As System.Windows.Forms.Button
    Friend WithEvents startRead As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dataBox As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_IP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
