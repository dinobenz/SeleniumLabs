using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Ysod.Magento.Tests
{
    /// <summary>
    /// The forms control test class.
    /// </summary>
    [TestFixture]
    public class FormsTest
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
            driver.Navigate().GoToUrl("https://docs.google.com/forms/d/1xTv3VIzZyFlhekgIEjT43fIR0U3vNK1OGgF3j_ny1sM/viewform");
        }

        /// <summary>
        /// Fill data to form and submit.
        /// </summary>
        [Test]
        public void SubmitForm()
        {
            // textinput
            driver.FindElement(By.XPath("//*[@id=\"entry_1978186045\"]")).SendKeys("My name is Pakorn");

            // textarea
            driver.FindElement(By.XPath("//*[@id=\"entry_2139123510\"]")).SendKeys("999/9\r\nBangkok\r\nThailand\r\n10000");

            // checkbox
            driver.FindElement(By.XPath("//*[@id=\"group_1913898819_3\"]")).Click();

            // radio
            driver.FindElement(By.XPath("//*[@id=\"group_1518003300_1\"]")).Click();

            // select
            var gender = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"entry_2384352\"]")));
            gender.SelectByValue("Hongkong");

            // button
            driver.FindElement(By.XPath("//*[@id=\"ss-submit\"]")).Submit();

            // wait
            System.Threading.Thread.Sleep(5000);

            // check result
            Assert.AreEqual("Form Title", driver.FindElement(By.XPath("/html/body/div/div/h1")).Text);
            Assert.AreEqual("Your form has been recorded.", driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]")).Text);
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
