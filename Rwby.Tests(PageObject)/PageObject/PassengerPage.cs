using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Rwby.Tests_PageObject_.PageObjects
{
    class PassengerPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [Obsolete]
        public PassengerPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//li[@class='item_1 cabinet']/a")]
        private IWebElement SearchLogInIcon;

        [FindsBy(How = How.Name, Using = "login")]
        private IWebElement Login;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//*[@value='Войти']")]
        private IWebElement LogInButton;


        [FindsBy(How = How.XPath, Using = "//ul[@class='list list-reset clearfix']/li[@class='item']/a[@href='/en/?c=true']")]
        private IWebElement LanguageButton;


        [Obsolete]
        public ResultPage Authorization(string login, string password)
        {
            SearchLogInIcon.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='modal-content']/div[@class='auth-modal__header']")));

            Login.SendKeys(login);
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.Name("login"), "dpitalenko"));

            Password.SendKeys(password);
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.Name("password"), "123456789rwby"));

            LogInButton.Click();
            wait.Until(ExpectedConditions.UrlToBe("https://pass.rw.by/ru/?path=ru%2F"));

            Logger.Logger.Log.Debug("m.Authorization");

            return new ResultPage(driver);
        }

        [Obsolete]
        public ResultPage ChangeLocalization()
        {
            LanguageButton.Click();
            wait.Until(ExpectedConditions.UrlToBe("https://pass.rw.by/en/?c=true"));
            Logger.Logger.Log.Debug("m.ChangeLocalization");
            return new ResultPage(driver);
        }
    }
}