using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Chloride
{
    /// <summary>
    /// Page element not found exception
    /// </summary>
    public class PageElementNotFoundException: Exception
    {
        /// <summary>
        /// Page element not found exception
        /// </summary>
        public PageElementNotFoundException()
            : base()
        {

        }

        /// <summary>
        /// Page element not found exception
        /// </summary>
        /// <param name="message">Exception message</param>
        public PageElementNotFoundException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Page element not found exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Internal exception</param>
        public PageElementNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
