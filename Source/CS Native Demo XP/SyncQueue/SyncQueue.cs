using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Data;
using System.Data.Common;

using CSLibrary.Data.SQLite;

namespace CSLibrary.Data
{
    public class SyncQueue : IDisposable
    {
        #region Member
        public const uint MaxBufferSize = 2000;
        private uint bufferSize = 1000;
        private const string databaseName = "Data Source=rfdb.db3;Pooling=true;FailIfMissing=false";
        private Thread mSyncQueueThread = null;
        private Queue messageQueue = null;
        private Queue synchQ = null;
        private int stopFlag = 0;
        private int stopped = 0;
        private bool isOpen = false;
        private AutoResetEvent startedThread = new AutoResetEvent(false);
        private DbProviderFactory _fact;
        private DbConnection _cnn = null;
        private DbConnectionStringBuilder _cnnstring;
        private object syncLock = new object();

        private Status status = Status.IDLE;

        private string tableName = "RFID";
        /// <summary>
        /// Evnet Delegate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CheckDataExistEventHandler(object sender, CheckDataExistEventArgs e);
        /// <summary>
        /// Data Check Exist Result
        /// </summary>
        public event CheckDataExistEventHandler OnCheckDataExist;
        /// <summary>
        /// Current status
        /// </summary>
        public Status Status
        {
            get { lock (syncLock) return status; }
            set { lock (syncLock) status = value; }
        }

        /// <summary>
        /// BufferSize can't excess <c>MaxBufferSize = 2000</c>
        /// </summary>
        public uint BufferSize
        {
            get { return bufferSize; }
            set 
            {
                if (value > MaxBufferSize)
                    throw new IndexOutOfRangeException(string.Format("BufferSize can't excess {0}", MaxBufferSize));
                bufferSize = value;
            }
        }
        #endregion

        #region ctor
        /// <summary>
        /// Constructor
        /// </summary>
        public SyncQueue()
        {
            messageQueue = new Queue();
            synchQ = Queue.Synchronized(messageQueue);

            using (DataTable tbl = DbProviderFactories.GetFactoryClasses())
            {
                foreach (DataRow row in tbl.Rows)
                {
                    string prov = row[2].ToString();

                    /*if (prov.IndexOf("SQLite", 0, StringComparison.OrdinalIgnoreCase) != -1
                      || prov.IndexOf("SqlClient", 0, StringComparison.OrdinalIgnoreCase) != -1
                      )
                        _provider.Items.Add(prov);*/
                    if (prov == "CSLibrary.Data.SQLite")
                    {
                        _fact = DbProviderFactories.GetFactory(prov);
                        break;
                    }
                }
            }
            
            _cnn = _fact.CreateConnection();
            _cnn.ConnectionString = databaseName;
            _cnnstring = _fact.CreateConnectionStringBuilder();
            _cnnstring.ConnectionString = databaseName;

        }
        #endregion

        #region Public

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bufferSize">BufferSize can't excess <c>MaxBufferSize = 2000</c></param>
        public SyncQueue(uint bufferSize)
        {
            messageQueue = new Queue();
            synchQ = Queue.Synchronized(messageQueue);

            _fact = DbProviderFactories.GetFactory("CSLibray.Data.SQLite");
            _cnn = _fact.CreateConnection();
            _cnn.ConnectionString = databaseName;
            _cnnstring = _fact.CreateConnectionStringBuilder();
            _cnnstring.ConnectionString = databaseName;
            this.BufferSize = bufferSize;
        }
        /// <summary>
        /// Release all resources
        /// </summary>
        public void Dispose()
        {
            synchQ.Clear();
            synchQ = messageQueue = null;
            _cnn.Close();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public SQLiteErrorCode Start()
        {
            SQLiteErrorCode result = SQLiteErrorCode.Ok;
            if (mSyncQueueThread == null || !mSyncQueueThread.IsAlive)
            {
                if ((result = Open()) != SQLiteErrorCode.Ok)
                {
                    return result;
                }
                Interlocked.Exchange(ref stopFlag, 0);
                mSyncQueueThread = new Thread(new ThreadStart(ThreadStart));
                mSyncQueueThread.IsBackground = true;
                mSyncQueueThread.Start();
                startedThread.WaitOne();
            }
            return result;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public SQLiteErrorCode Stop()
        {
            if (this.Status == Status.BUSY)
            {
                Interlocked.Exchange(ref stopFlag, 1);

                if (mSyncQueueThread != null)
                    mSyncQueueThread.Join();
            }
            //ClearBuffer?
            return Close();
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public SQLiteErrorCode Pause()
        {
            if (mSyncQueueThread != null && mSyncQueueThread.IsAlive)
            {
                mSyncQueueThread.Suspend();
                this.Status = Status.PAUSE;
            }
            return SQLiteErrorCode.Ok;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public SQLiteErrorCode Resume()
        {
            if (mSyncQueueThread != null && mSyncQueueThread.IsAlive)
            {
                mSyncQueueThread.Resume();
                this.Status = Status.BUSY;
            }
            return SQLiteErrorCode.Ok;
        }
        public SQLiteErrorCode Clear()
        {
            Pause();
            RemoveAll();
            Resume();
            synchQ.Clear();
            return SQLiteErrorCode.Ok;
        }
        public SQLiteErrorCode Write(string data)
        {
            if (synchQ.Count >= BufferSize)
                return SQLiteErrorCode.Full;
            synchQ.Enqueue(data);
            return SQLiteErrorCode.Ok;
        }
        #endregion

        #region Internal use
        /// <summary>
        /// Open Database
        /// </summary>
        /// <returns></returns>
        private SQLiteErrorCode Open()
        {
            SQLiteErrorCode result = SQLiteErrorCode.Ok;
            if (!isOpen)
            {
                try
                {
                    _cnn.Open();
                    isOpen = true;
                    CreateTable();
                    RemoveAll();
                }
                catch(SQLiteException ex)
                {
                    result = ex.ErrorCode;
                }
            }
            return result;
        }
        /// <summary>
        /// Close Database
        /// </summary>
        /// <returns></returns>
        private SQLiteErrorCode Close()
        {
            SQLiteErrorCode result = SQLiteErrorCode.Ok;
            try
            {
                if (isOpen)
                {
                    DeleteTable();
                    _cnn.Close();
                    isOpen = false;
                }
            }
            catch (SQLiteException ex)
            {
                result = ex.ErrorCode;
            }
            return result;
        }

        private SQLiteErrorCode Add(string data)
        {
            return Add(tableName, data);
        }
        private SQLiteErrorCode Add(string tableName, string data)
        {
            SQLiteErrorCode result = SQLiteErrorCode.Ok;
            try
            {
                using (DbCommand cmd = _cnn.CreateCommand())
                {
                    cmd.CommandText = string.Format("insert into {0}(epc) values('{1}');", tableName, data);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SQLiteException ex)
            {
                result = ex.ErrorCode;
            }
            return result;
        }
        private SQLiteErrorCode Remove(string data)
        {
            return Remove(tableName, data);
        }
        private SQLiteErrorCode Remove(string tableName, string data)
        {
            SQLiteErrorCode result = SQLiteErrorCode.Ok;
            try
            {
                using (DbCommand cmd = _cnn.CreateCommand())
                {
                    cmd.CommandText = string.Format("delete from {0} where epc='{1}';", tableName, data);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                result = ex.ErrorCode;
            }
            return result;
        }
        private SQLiteErrorCode RemoveAll(string tableName)
        {
            if (!isOpen)
            {
                return SQLiteErrorCode.CantOpen;
            }
            SQLiteErrorCode result = SQLiteErrorCode.Ok;
            try
            {
                using (DbCommand cmd = _cnn.CreateCommand())
                {
                    cmd.CommandText = string.Format("drop table {0};", tableName);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = string.Format("create table {0}(epc blob unique);", tableName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                result = ex.ErrorCode;
            }
            return result;
        }
        private SQLiteErrorCode RemoveAll()
        {
            if (!isOpen)
            {
                return SQLiteErrorCode.CantOpen;
            }
            SQLiteErrorCode result = SQLiteErrorCode.Ok;
            try
            {
                using (DbCommand cmd = _cnn.CreateCommand())
                {
                    cmd.CommandText = string.Format("drop table {0};", tableName);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = string.Format("create table {0}(epc blob unique);", tableName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                result = ex.ErrorCode;
            }
            return result;
        }
        /*private bool CheckTableExist()
        {
            using (DbCommand cmd = _cnn.CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT name FROM {0} WHERE name='{0}'", tableName);
                DbDataReader rdr = cmd.ExecuteReader();
            }
        }*/

        private SQLiteErrorCode CreateTable()
        {
            if (!isOpen)
            {
                return SQLiteErrorCode.CantOpen;
            }
            return CreateTable(tableName);
        }
        private SQLiteErrorCode CreateTable(string tableName)
        {
            try
            {
                using (DbCommand cmd = _cnn.CreateCommand())
                {
                    cmd.CommandText = string.Format("create table {0}(epc blob unique);", tableName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {

            }
            return SQLiteErrorCode.Ok;
        }
        private SQLiteErrorCode DeleteTable()
        {
            if (!isOpen)
            {
                return SQLiteErrorCode.CantOpen;
            }
            return DeleteTable(tableName);
        }
        private SQLiteErrorCode DeleteTable(string tableName)
        {
            SQLiteErrorCode result = SQLiteErrorCode.Ok;
            try
            {
                using (DbCommand cmd = _cnn.CreateCommand())
                {
                    cmd.CommandText = string.Format("drop table {0};", tableName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                result = ex.ErrorCode;
            }
            return result;
        }
        private void ThreadStart()
        {
            this.Status = Status.BUSY;
            startedThread.Set();
            while (!Interlocked.Equals(stopFlag, 1))
            {
                if (synchQ.Count > 0)
                {
                    string data = synchQ.Dequeue() as string;
                    SQLiteErrorCode result = Add(data);
                    if (OnCheckDataExist != null)
                    {
                        OnCheckDataExist(this, new CheckDataExistEventArgs(data, result == SQLiteErrorCode.Constraint));
                    }
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
            Interlocked.Exchange(ref stopped, 1);
            this.Status = Status.IDLE;
        }

        #endregion

    }
}
