using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Rwby.Tests_PageObject_.PageObjects
{
    class ResultPage
    {
        private IWebDriver driver;

        [Obsolete]
        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//li[@class='item_1 cabinet']/a/span[text()='Диана Питаленко']")]
        private IWebElement IsAuth;

        public IWebElement IsLogIn()
        {
            return IsAuth;
        }

        public bool IsUrlCorrect()
        {
            return (driver.Url).Equals("https://pass.rw.by/en/?c=true");
        }
    }
}