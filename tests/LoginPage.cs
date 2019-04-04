using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace tests
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly By _username = By.Id("okta-signin-username");
        private readonly By _password = By.Id("okta-signin-password");
        private readonly By _loginButton = By.Id("okta-signin-submit");
        private readonly By _failedLoginDiv = By.ClassName("okta-form-infobox-error");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public LoginPage NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
            return this;
        }

        public LoginPage AttemptLogin(string username, string password)
        {
            _driver.FindElement(_username).SendKeys(username);
            _driver.FindElement(_password).SendKeys(password);
            _driver.FindElement(_loginButton).Click();
            return this;
        }

        public LoginPage WaitUntilErrorMessageAppears()
        {
            _ = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(driver => driver.FindElement(_failedLoginDiv));
            return this;
        }

        public string GetLoginErrorMessage()
        {
            return _driver.FindElement(_failedLoginDiv).Text;
        }
    }
}