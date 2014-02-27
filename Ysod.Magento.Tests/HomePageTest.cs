using NUnit.Framework;
using OpenQA.Selenium;

namespace Ysod.Magento.Tests
{
    /// <summary>
    /// The home page test class.
    /// </summary>
    [TestFixture]
    public class HomePageTest
    {
        /// <summary>
        /// The web driver.
        /// </summary>
        IWebDriver driver;

        /// <summary>
        /// Do before test run.
        /// </summary>
        [SetUp]
        public void DoBeforeTest()
        {
            driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
        }

        /// <summary>
        /// Test open website.
        /// </summary>
        [Test]
        public void OpenWebsite()
        {
            driver.Navigate().GoToUrl("http://www.ysod.net");

            Assert.AreEqual("Ysod.NET | Yellow Screen of Death", driver.Title);
        }

        /// <summary>
        /// Do after test run.
        /// </summary>
        [TearDown]
        public void DoAfterTest()
        {
            driver.Close();
        }
    }
}
