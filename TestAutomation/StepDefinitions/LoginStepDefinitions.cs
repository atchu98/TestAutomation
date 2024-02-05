using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TestAutomation.TestData;
using TestAutomation.Pages;
using FluentAssertions.Execution;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace TestAutomation.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private SearchPage searchPage;
        private WebDriverWait wait;

        LoginTestData loginData = new LoginTestData();
        SearchPageData searchPageData = new SearchPageData();



        public LoginStepDefinitions(IWebDriver driver, LoginPage loginPage, SearchPage searchPage)
        {
            this.driver = driver;
            this.loginPage = new LoginPage(driver);
            this.searchPage = new SearchPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
        }

        [Given(@"I launch my browser and go to the login page")]
        public void GivenILaunchMyBrowserAndGoToTheLoginPage()
        {

            //driver.Navigate().GoToUrl(string.Concat(loginData.baseloginURL ,loginData.loginURL));
            loginPage.DirectToLoginUrl(driver);

        }

        [When(@"I click login with the Mestec Account")]
        public void WhenIClickLoginWithTheMestecAccount()
        {
            
            //wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(loginData.loginWithMestecButtonByID)));
            loginPage.WaitUntilElementIsVisible(driver,200,loginData.loginWithMestecButtonByID);
            
            loginPage.ClickonLoginWithMestec(driver);
            
        }



        [Then(@"I move to the page to login using Mestec account")]
        public void ThenIMoveToThePageToLoginUsingMestecAccount()
        {
            
            //wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(loginData.loginWithAzureADFieldByID)));
            loginPage.WaitUntilElementIsVisible(driver, 200, loginData.loginWithAzureADFieldByID);
            Assert.IsTrue(loginPage.CheckUsernameFieldDisplayed(driver));
            Assert.IsTrue((loginPage.CheckPasswordFieldDisplayed(driver)));
            Assert.IsTrue(loginPage.CheckMestecAccountLoginButtonDisplayed(driver));
        }





        [When(@"I login with the Mestec Account")]
        public void WhenILoginWithTheMestecAccount()
        {

            ////wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            ////wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(loginData.loginWithMestecButtonByID)));
            //loginPage.WaitUntil(driver, 200, loginData.loginWithMestecButtonByID);
            //loginPage.ClickonLoginWithMestec(driver);

            ////wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(loginData.loginWithAzureADFieldByID)));
            //loginPage.WaitUntil(driver, 200, loginData.loginWithAzureADFieldByID);

            //loginPage.LoginWithMestecAccount_Non_SSO(driver);
            //Thread.Sleep(2000);    

            //if (loginPage.CheckAlreadyLoggedInPopupDisplayed(driver) == true)
            //{
            //    loginPage.AlreadyLoggedInPopup(driver);
            //}

            loginPage.LoginIntoMestec(driver);

        }


        [Then(@"I go to the home screen")]
        public void ThenIGoToTheHomeScreen()
        {
            
            //wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(searchPageData.searchPageTitleId)));
            loginPage.WaitUntilElementIsVisible(driver, 200, searchPageData.searchPageTitleId);

            Thread.Sleep(1000);
           
            
            Assert.AreEqual(searchPageData.searchPageTitle, searchPage.GetSearchPageTitle(driver));
            Assert.AreEqual(string.Concat(loginData.baseloginURL, searchPageData.searchPageURL), driver.Url.ToString());

            
        }

        [When(@"I try to login  to Mestec with wrong details")]
        public void WhenITryToLoginToMestecWithWrongDetails(Table table)
        {
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(loginData.loginWithMestecButtonByID)));

            loginPage.ClickonLoginWithMestec(driver);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(loginData.loginWithAzureADFieldByID)));

            foreach (var row in table.Rows) 
            {
                string username = row["Username"];
                string password = row["Password"];

                loginPage.LoginWithMestecAccount_Non_SSODD(driver, username, password);
                
               
            }
            
        }

        [Then(@"I should see error message")]
        public void ThenIShouldSeeErrorMessage()
        {
            
            Assert.IsTrue(loginPage.LoginFailedErrorDisplayed(driver));
            
            Assert.AreEqual(loginData.failedLoginResponse, loginPage.LoginFailedErrorText(driver));
            
            
        }


        [When(@"I change my shift")]
        public void WhenIChangeMyShift()
        {
           
            Thread.Sleep(2000);
            searchPageData.shiftBefore = searchPage.GetShiftInfo(driver);
            searchPage.FindTheUserMenuButton(driver).Click();
            
            
            Console.WriteLine(1);
            Thread.Sleep(2000);
            searchPage.FindTheChangeShiftButton(driver).Click();
            Console.WriteLine(2);
            Thread.Sleep(2000);
           
            searchPage.ClickOnAnotherShiftThatIsNotSelected(driver);
            Thread.Sleep(3000);
            searchPageData.shiftAfter = searchPage.GetShiftInfo(driver);
            Console.WriteLine(searchPageData.shiftAfter);
            Thread.Sleep(4000);
        }

        [Then(@"the shift changes")]
        public void ThenTheShiftChanges()
        {
            Console.WriteLine(searchPageData.shiftBefore);
            Console.WriteLine(searchPageData.shiftAfter);
            Assert.AreNotEqual(searchPageData.shiftBefore, searchPageData.shiftAfter);
        }

        [When(@"I Logout")]
        public void WhenILogout()
        {
            Thread.Sleep(3000);
            searchPage.FindTheUserMenuButton(driver).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.LinkText("Log Out")).Click();
        }

        [Then(@"I am on the Login Page")]
        public void ThenIAmOnTheLoginPage()
        {
            Thread.Sleep(3000);
            Assert.AreEqual(string.Concat(loginData.baseloginURL, loginData.loginURL), driver.Url.ToString());
        }


        //[When(@"I go to Workflow")]
        //public void WhenIGoToWorkflow()
        //{

        //    wait.PollingInterval = TimeSpan.FromMilliseconds(200);
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("menusearchtext")));
        //    var search = driver.FindElement(By.Id("menusearchtext"));

        //    search.Clear();
        //    search.SendKeys("Workflow");
        //    search.SendKeys(Keys.Enter);
        //    Thread.Sleep(1000);
        //    driver.FindElement(By.LinkText("Workflow")).Click();
        //    Thread.Sleep(1000);
        //    driver.FindElement(By.XPath("//button[text()='New']")).Click();
        //    Thread.Sleep(2000);


        //    Console.WriteLine(0);
        //    IWebElement element = driver.FindElement(By.XPath("//*[contains(@id, 'LineConfigDropDown')]/span/span/span[1]"));
        //    //IWebElement element = driver.FindElements(By.ClassName("k-widget k-dropdown validate-input"))[2];
        //    Console.WriteLine( element.GetAttribute("id"));

        //    Actions actions = new Actions(driver);

        //    // Perform the hover action
        //    actions.MoveToElement(element).Perform();
        //    actions.Click(element).Perform();
        //    Thread.Sleep(2000);
        //    var lineconfigdropdownelement = driver.FindElement(By.PartialLinkText("Adam"));
        //        //driver.FindElement(By.XPath("//ul/li[contains(text(), 'Adam')]"));
        //    actions.Click(lineconfigdropdownelement).Perform();


        //    Thread.Sleep(3000);  


        //}

        //[Then(@"I go to the go")]
        //public void ThenIGoToTheGo()
        //{
        //    Assert.Pass();
        //}


    }
}
