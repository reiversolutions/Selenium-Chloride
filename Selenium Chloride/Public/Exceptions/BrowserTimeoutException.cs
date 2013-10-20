using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Chloride
{
    /// <summary>
    /// Browser timeout exception
    /// </summary>
    public class BrowserTimeoutException : Exception
    {
        /// <summary>
        /// Browser timeout exception
        /// </summary>
        public BrowserTimeoutException()
            : base()
        {

        }

        /// <summary>
        /// Browser timeout exception
        /// </summary>
        /// <param name="message">Exception message</param>
        public BrowserTimeoutException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Browser timeout exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Internal exception</param>
        public BrowserTimeoutException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
