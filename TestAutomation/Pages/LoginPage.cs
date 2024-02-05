using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.TestData;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace TestAutomation.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        LoginTestData loginData = new LoginTestData(); 
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
        }

        public LoginPage DirectToLoginUrl(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(string.Concat(loginData.baseloginURL, loginData.loginURL));
            return this;
        }

        public LoginPage ClickonLoginWithMestec(IWebDriver driver)
        {
            driver.FindElement(By.Id(loginData.loginWithMestecButtonByID)).Click();
            return this;
        }

        

        public bool CheckUsernameFieldDisplayed(IWebDriver driver)
        {
            try
            {
                return driver.FindElement(By.Id(loginData.usernameFieldByID)).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
             
            
        }

        public bool CheckPasswordFieldDisplayed(IWebDriver driver)
        {
            try
            {
                return driver.FindElement(By.Id(loginData.passwordFieldByID)).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }


        }

        public bool CheckMestecAccountLoginButtonDisplayed(IWebDriver driver)
        {
            
            try
            {
                return driver.FindElement(By.Id(loginData.loginButtonFieldByID)).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public LoginPage LoginWithMestecAccount_Non_SSO(IWebDriver driver)
        {
            driver.FindElement(By.Id(loginData.usernameFieldByID)).SendKeys(loginData.username);
            driver.FindElement(By.Id(loginData.passwordFieldByID)).SendKeys(loginData.password);
            driver.FindElement(By.Id(loginData.loginButtonFieldByID)).Click();
            return this;
        }

        public LoginPage LoginWithMestecAccount_Non_SSODD(IWebDriver driver, string username, string password)
        {
            driver.FindElement(By.Id(loginData.usernameFieldByID)).Clear();
            driver.FindElement(By.Id(loginData.passwordFieldByID)).Clear();
            driver.FindElement(By.Id(loginData.usernameFieldByID)).SendKeys(username);
            driver.FindElement(By.Id(loginData.passwordFieldByID)).SendKeys(password);
            Thread.Sleep(1000);
            driver.FindElement(By.Id(loginData.loginButtonFieldByID)).Click();
            return this;
        }

        public bool CheckAlreadyLoggedInPopupDisplayed(IWebDriver driver)
        {
            
            try
            {
                return driver.FindElement(By.XPath(loginData.checkAlreadyLoggedInButtonXpath)).Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        public LoginPage AlreadyLoggedInPopup(IWebDriver driver) 
        {
           
                 driver.FindElement(By.XPath(loginData.checkAlreadyLoggedInButtonXpath)).Click();
                return this;
        }

        public bool LoginFailedErrorDisplayed(IWebDriver driver)
        {
            return driver.FindElement(By.Id(loginData.failedLoginFieldByID)).Displayed;
            
        }
        public string LoginFailedErrorText(IWebDriver driver)
        {
            return driver.FindElement(By.Id(loginData.failedLoginFieldByID)).Text;

        }

        public LoginPage WaitUntilElementIsVisible(IWebDriver driver, int time, string elementToWaitFor)
        {
            wait.PollingInterval = TimeSpan.FromMilliseconds(time);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(elementToWaitFor)));

            return this;
        }

        public LoginPage LoginIntoMestec(IWebDriver driver)
        { 
            //wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(loginData.loginWithMestecButtonByID)));
            WaitUntilElementIsVisible(driver, 200, loginData.loginWithMestecButtonByID);
            ClickonLoginWithMestec(driver);

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(loginData.loginWithAzureADFieldByID)));
            WaitUntilElementIsVisible(driver, 200, loginData.loginWithAzureADFieldByID);

            LoginWithMestecAccount_Non_SSO(driver);

            Thread.Sleep(2000);

            if (CheckAlreadyLoggedInPopupDisplayed(driver) == true)
            {
                AlreadyLoggedInPopup(driver);
            }

            return this;
        }

    }
}
