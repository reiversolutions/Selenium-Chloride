using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Chloride
{
    /// <summary>
    /// Incorrect config exception
    /// </summary>
    public class ConfigException : Exception
    {
        /// <summary>
        /// Incorrect config exception
        /// </summary>
        public ConfigException()
            : base()
        {

        }

        /// <summary>
        /// Incorrect config exception
        /// </summary>
        /// <param name="message">Exception message</param>
        public ConfigException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Incorrect config exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Internal exception</param>
        public ConfigException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
