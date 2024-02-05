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
using Newtonsoft.Json;
using OpenQA.Selenium.DevTools;



namespace TestAutomation.StepDefinitions
{
    [Binding]
    public class WorkflowStepDefinitions
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private SearchPage searchPage;
        private WebDriverWait wait;
        

        LoginTestData loginData = new LoginTestData();
        SearchPageData searchPageData = new SearchPageData();
        



        public WorkflowStepDefinitions(IWebDriver driver, LoginPage loginPage, SearchPage searchPage)
        {
            this.driver = driver;
            this.loginPage = new LoginPage(driver);
            this.searchPage = new SearchPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
        }
        
        

        [When(@"I go to Workflow")]
        public void WhenIGoToWorkflowAsync()
        {
            
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("menusearchtext")));
            var search = driver.FindElement(By.Id("menusearchtext"));

            search.Clear();
            search.SendKeys("Workflow");
            search.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Workflow")).Click();
            Thread.Sleep(1000);

          


            driver.FindElement(By.XPath("//button[text()='New']")).Click();
            Thread.Sleep(4000);
            
  
            Console.WriteLine(0);

            var ele4 = driver.FindElements(By.XPath("//*[starts-with(@id, 'PageLayout')]"));

            Console.WriteLine(ele4[0].GetAttribute("id"));
            foreach (var ele in ele4)
            {
                Console.WriteLine(ele.GetAttribute("id"));
            }


            Console.WriteLine("Print this");

            int lengthToRemove = "PageLayout".Length;
            string modifiedString = ele4[1].GetAttribute("id").ToString().Substring(lengthToRemove);
            Console.WriteLine(modifiedString);

            driver.FindElement(By.Id("DIV_LineTypeDownDown" + modifiedString)).Click();
            Thread.Sleep(3000);

            Actions actions = new Actions(driver);
            var idtoclick = driver.FindElement(By.Id("LineTypeDownDown" + modifiedString));
            //Console.WriteLine(idtoclick.GetAttribute("value"));
            actions.MoveToElement(idtoclick);
            
            Thread.Sleep(10000);

            //IGNORE


            //IWebElement element = driver.FindElement(By.XPath("//*[starts-with(@id, 'DIV_LineConfigDropDown')]/span/span/span[1]"));
            //IWebElement element = driver.FindElement(By.XPath("/html/body/div[1]/form/div[5]/div[2]/div/div[1]/div/fieldset/div[2]/span/span/span[1]"));
            //var val =  element.GetAttribute("id");
            //Console.WriteLine(val);
            //IWebElement trial = driver.FindElement(By.Id(val));
            // IWebElement test = driver.FindElement(By.XPath("//*[starts-with(@id, 'DIV_LineTypeDropDown')]/span/span/span[1]"));
            //Actions actions = new Actions(driver);
            //Console.WriteLine(test.GetAttribute("id"));
            //// Perform the hover action
            //actions.MoveToElement(element).Perform();
            //actions.Click(element).Perform();
            //Thread.Sleep(2000);
            //var ele = driver.FindElement(By.XPath("/html/body/div[16]/div/div[2]/ul/li[3]"));

            //ele.Click();    
            //var eleAttribute = ele.GetAttribute("id");
            //SelectElement selectElement = new SelectElement(ele);
            ////var lineconfigdropdownelement = 
            //selectElement.SelectByIndex(3);
            //driver.FindElement(By.PartialLinkText("Adam"));
            //driver.FindElement(By.XPath("//ul/li[contains(text(), 'Adam')]"));
            //actions.Click(lineconfigdropdownelement).Perform();


            //Thread.Sleep(23000);  


        }

        [Then(@"I create a workflow")]
        public void ThenICreateAWorkflow()
        {
            throw new PendingStepException();
        }



    }
}
