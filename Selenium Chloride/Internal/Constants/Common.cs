using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Selenium_Chloride.Internal.Constants
{
    internal class Common
    {
        /// <summary>
        /// Webbrowser type
        /// </summary>
        internal static string Browser = ConfigurationManager.AppSettings["Browser"];

        /// <summary>
        /// Grid path location
        /// </summary>
        internal static string GridPath = ConfigurationManager.AppSettings["GridPath"];

        /// <summary>
        /// Site url
        /// </summary>
        internal static string SiteUrl = ConfigurationManager.AppSettings["SiteUrl"];

        /// <summary>
        /// Path to .poml files
        /// </summary>
        internal static string PomlFiles = ConfigurationManager.AppSettings["PomlDir"];

        /// <summary>
        /// Path to PrintScreen file storage
        /// </summary>
        internal static string PrintScreenFiles = ConfigurationManager.AppSettings["PrintScreenDir"];

        /// <summary>
        /// Driver timeout
        /// </summary>
        internal static TimeSpan BrowserTimeout
        {
            get { return _defaultTimeSpan; }
            set { _defaultTimeSpan = value; }
        }
        private static TimeSpan _defaultTimeSpan = new TimeSpan(0, 0, 30);
    }
}