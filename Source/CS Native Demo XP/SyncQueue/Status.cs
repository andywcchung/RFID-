using System;
using System.Collections.Generic;
using System.Text;

namespace CSLibrary.Data
{
    public enum Status
    {
        /// <summary>
        /// not started
        /// </summary>
        IDLE,
        /// <summary>
        /// started
        /// </summary>
        BUSY,
        /// <summary>
        /// Operation Aborted
        /// </summary>
        ABORT,
        /// <summary>
        /// Pause
        /// </summary>
        PAUSE,
    }
}
