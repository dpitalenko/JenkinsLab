using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Rwby.Tests_PageObject_.PageObjects;
using System;
using Rwby.Tests_PageObject_.Logger;

namespace Rwby.Tests_PageObject_
{
    [TestClass]
    public class RwbtTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void BrowserSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            Logger.Logger.InitLogger();
            Logger.Logger.Log.Info("INIT!");
        }

        [TestMethod]
        [Obsolete]
        public void CorrectLogIn()
        {
            try
            {
                HomePage home = new HomePage(driver);
                home.GoToPage();
                PassengerPage passengerPage = home.GoToPassengerPage();
                ResultPage result = passengerPage.Authorization("dpitalenko", "123456789rwby");
                Assert.IsNotNull(result.IsLogIn());
                Logger.Logger.Log.Info("Test success!");
                Logger.Logger.TakeScreenshot(driver, @"Log\success.png");
            }
            catch(Exception error)
            {
                Logger.Logger.TakeScreenshot(driver, @"Log\error.png");
                Logger.Logger.Log.Error("Test error:" + error.Message);
          
            }
           
        }

        [TestMethod]
        [Obsolete]
        public void ChangeLocationToENG()
        {
            try
            {
                HomePage home = new HomePage(driver);
                home.GoToPage();
                PassengerPage passengerPage = home.GoToPassengerPage();
                ResultPage result = passengerPage.ChangeLocalization();
                Assert.IsTrue(result.IsUrlCorrect());
                Logger.Logger.Log.Info("Test success!");
                Logger.Logger.TakeScreenshot(driver, @"Log\success2.png");
            }
            catch(Exception error)
            {
                Logger.Logger.TakeScreenshot(driver, @"Log\error2.png");
                Logger.Logger.Log.Error("Test error:" + error.Message);
            }
        }

        [TestCleanup]
        public void BrowserTearDown()
        {
            Logger.Logger.Log.Info("END!");
            driver.Quit();
            driver = null;
        }
    }
}