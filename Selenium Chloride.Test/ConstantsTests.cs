using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium_Chloride.Internal.Constants;

namespace Selenium_Chloride.Test
{
    /// <summary>
    /// Test constants
    /// </summary>
    [TestClass]
    public class ConstantsTests
    {
        [TestMethod]
        public void Common_ValidAppConfigKey_Test()
        {
            // Assign
            string result = null;

            // Act
            result = Common.Browser;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void Common_InvalidAppConfigKey_Test()
        {
            // Assign
            string result = null;

            // Act
            result = Common.GridPath;

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}
