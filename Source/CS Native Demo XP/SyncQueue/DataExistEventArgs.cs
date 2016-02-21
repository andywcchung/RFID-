using System;
using System.Collections.Generic;
using System.Text;

namespace CSLibrary.Data
{
    /// <summary>
    /// Check data exist callback event argument
    /// </summary>
    public class CheckDataExistEventArgs : EventArgs
    {
        /// <summary>
        /// Data
        /// </summary>
        public readonly string Data = null;
        /// <summary>
        /// Already exist in the database
        /// </summary>
        public readonly bool IsExist = false;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="exist">exist in database</param>
        public CheckDataExistEventArgs(string data, bool exist)
        {
            this.Data = data;
            this.IsExist = exist;
        }
    }
}
