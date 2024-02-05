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

namespace TestAutomation.StepDefinitions
{
    [Binding]
    public class DocumentStepDefinitions
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private SearchPage searchPage;
        private DocumentManagerPage documentManagerPage;
        private WebDriverWait wait;

        LoginTestData loginData = new LoginTestData();
        SearchPageData searchPageData = new SearchPageData();
        DocumentManagerPageData documentManagerPageData = new DocumentManagerPageData();
        



        public DocumentStepDefinitions(IWebDriver driver, LoginPage loginPage, SearchPage searchPage, DocumentManagerPage documentManagerPage)
        {
            this.driver = driver;
            this.loginPage = new LoginPage(driver);
            this.searchPage = new SearchPage(driver);
            this.documentManagerPage = new DocumentManagerPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            
        }
        
    
        [Given(@"I have successfully logged in")]
        public void GivenIHaveSuccessfullyLoggedIn()
        {
            loginPage.DirectToLoginUrl(driver);
            loginPage.LoginIntoMestec(driver);
            Thread.Sleep(5000);
        }

        [When(@"I go to the Document Manager")]
        public void WhenIGoToTheDocumentManager()
        {
            
            searchPage.SearchItemInMenuSearch(driver, searchPageData.documentManagerSearchItem);
            Thread.Sleep(2500);

            //driver.FindElement(By.LinkText("Document Manager")).Click();
            searchPage.FindItemFromSearchResults_MenuSearch(driver, searchPageData.documentManagerSearchItem).Click();
            Thread.Sleep(2500);
            Console.WriteLine(driver.Url.ToString());
            
        }




        [When(@"I upload a document")]
        public void WhenIUploadADocument()
        {
            Thread.Sleep(3000);

            //driver.FindElement(By.XPath("//button[text()='Upload Document']")).Click();
            documentManagerPage.FindUploadDocumentButtonInDocumentmanager(driver).Click();
            Thread.Sleep(1800);
            var ele4 = driver.FindElements(By.XPath("//*[starts-with(@id, 'PageLayout')]"));

            Console.WriteLine(ele4[0].GetAttribute("id"));
            foreach (var ele in ele4)
            {
                Console.WriteLine(ele.GetAttribute("id"));
            }
            documentManagerPage.UploadADocumentToDocumentManager(driver);
            
            //driver.FindElement(By.XPath("//*[contains(@id,'Upload')]")).Click();
            //Thread.Sleep(2000);
            //IWebElement fileInput = driver.FindElement(By.Name("files"));
            //// Specify the path to the file you want to upload
            ////string filePath =  documentManagerPageData.txtFileTest;

            //// Send the file path to the file input element
            ////fileInput.SendKeys("C:\\Users\\AtchuthanSoorasangar\\Documents\\TestAutomation\\TestDocFiles\\testJpg.jpg");
            ////fileInput.SendKeys(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\net6.0", "TestDocFiles\\testJpg.jpg"));

            //string relativeFilePath = "TestDocFiles\\testJpg.jpg";

            //// Get the full absolute path to the file
            //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //string absoluteFilePath = Path.GetFullPath(Path.Combine(baseDirectory.Replace("bin\\Debug\\net6.0", ""), relativeFilePath));

            //fileInput.SendKeys(absoluteFilePath);


            Thread.Sleep(6000);
        }

        [Then(@"the document should be available in the Document Manager")]
        public void ThenTheDocumentShouldBeAvailableInTheDocumentManager()
        {
            documentManagerPage.CloseDocumentUploaderPopupFromDocumentManager(driver).Click();
            Thread.Sleep(1000);

            documentManagerPage.SearchForDocumentInDocumentManagerTable(driver, documentManagerPageData.documentNameToSearch);

            Thread.Sleep(4000);
            var table = driver.FindElement(By.XPath("//*[contains(@id,'DocumentsGrid')]/div[3]/table"));

            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));

            string searchTextForDoucumentManagerTable = "testJpg";

            // Flag to indicate if the item was found in the table
            bool isItemFoundInDocumentManagerTable = false;

            // Iterate through the rows and check if the item is present in any of the rows
            foreach (IWebElement row in rows)
            {
                // Find the columns of the row
                IList<IWebElement> columns = row.FindElements(By.TagName("td"));

                // Check if any of the columns contains the search text
                foreach (IWebElement column in columns)
                {

                    if (column.Text.Contains(searchTextForDoucumentManagerTable))
                    {
                        isItemFoundInDocumentManagerTable = true;
                        break;
                    }
                }

                if (isItemFoundInDocumentManagerTable)
                {
                    // Item found in the table

                    break;
                }
            }

            ///Perform actions based on the result
            //documentManagerPage.FindDocumentInDocumentManagerTable(driver);
            Assert.IsTrue(isItemFoundInDocumentManagerTable);
            //Assert.IsTrue(documentManagerPageData.isItemFoundInDocumentManagerTable);
            Assert.AreEqual(string.Concat(loginData.baseloginURL, documentManagerPageData.documentManagerPageUrl), driver.Url.ToString());
        }

        [Then(@"Delete the test document")]
        public void ThenDeleteTheTestDocument()
        {
            var table = driver.FindElement(By.XPath("//*[contains(@id,'DocumentsGrid')]/div[3]/table"));
            string searchTextForDoucumentManagerTable = "testJpg";
            Thread.Sleep(1000);
            var ele3 = driver.FindElements(By.XPath("//*[starts-with(@id, 'PageLayout')]"));

            Console.WriteLine(ele3[0].GetAttribute("id"));
            foreach (var ele in ele3)
            {
                Console.WriteLine(ele.GetAttribute("id"));
            }

            IWebElement rowContainingItem = table.FindElements(By.TagName("tr"))
               .FirstOrDefault(row => row.FindElements(By.TagName("td"))
                                       .Any(column => column.Text.Contains(searchTextForDoucumentManagerTable)));
            rowContainingItem.Click();

            driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            
            Thread.Sleep(1000);
            

            var okayButton = driver.FindElements(By.XPath("//button[text()='OK']"));
            IWebElement okButton = okayButton[2];
            okButton.Click();

        }




        [When(@"I go to the Data File Manager")]
        public void WhenIGoToTheDataFileManager()
        {
            searchPage.SearchItemInMenuSearch(driver, searchPageData.dataFileManagerSearchItem);
            Thread.Sleep(2500);
            searchPage.FindItemFromSearchResults_MenuSearch(driver, searchPageData.dataFileManagerSearchItem).Click();
            Thread.Sleep(2500);
            Console.WriteLine(driver.Url.ToString());
            
        }

        [When(@"I upload a single data file")]
        public void WhenIUploadASingleDataFile()
        {
            throw new PendingStepException();
        }

        [Then(@"the file should be available in the Data File Manager")]
        public void ThenTheFileShouldBeAvailableInTheDataFileManager()
        {
            throw new PendingStepException();
        }

        [When(@"I upload a multiple data files")]
        public void WhenIUploadAMultipleDataFiles(Table table)
        {
            throw new PendingStepException();
        }



    }
}
