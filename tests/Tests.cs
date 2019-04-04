using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using tests;

namespace Tests
{
    public class Tests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
        }

        [Test]
        public void Login_InvalidCredentials_ErrorMessageShowed()
        {
            _loginPage = new LoginPage(_driver);
            _loginPage
                .NavigateTo("https://www.smilereminder.com/sr/login.jsp")
                .AttemptLogin("fakeUsername", "fakePassword")
                .WaitUntilErrorMessageAppears();
            Assert.AreEqual(_loginPage.GetLoginErrorMessage(), "Sign in failed!");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}