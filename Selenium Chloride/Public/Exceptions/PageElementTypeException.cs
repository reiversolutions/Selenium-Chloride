using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Chloride
{
    /// <summary>
    /// Page element has an invalid type exception
    /// </summary>
    public class PageElementTypeException : Exception
    {
        /// <summary>
        /// Page element has an invalid type exception
        /// </summary>
        public PageElementTypeException()
            : base()
        {

        }

        /// <summary>
        /// Page element has an invalid type exception
        /// </summary>
        /// <param name="message">Exception message</param>
        public PageElementTypeException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Page element has an invalid type exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Internal exception</param>
        public PageElementTypeException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
