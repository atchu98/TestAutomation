using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.TestData;

namespace TestAutomation.Pages
{
    
    public class DocumentManagerPage
    {
        private IWebDriver driver;
        DocumentManagerPageData documentMangerPageData = new DocumentManagerPageData();
        public DocumentManagerPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        

        public IWebElement FindUploadDocumentButtonInDocumentmanager(IWebDriver driver)
        {
            return driver.FindElement(By.XPath(documentMangerPageData.documentManagerUploadButtonByXpath));
               
        }

        public DocumentManagerPage UploadADocumentToDocumentManager(IWebDriver driver) 
        {
            driver.FindElement(By.XPath(documentMangerPageData.uploadFileToDocumentMAnagerTableByXpath)).Click();
            Thread.Sleep(2000);
            IWebElement fileInput = driver.FindElement(By.Name(documentMangerPageData.documentManagerTableFileInputByName));
            // Specify the path to the file you want to upload
            //string filePath =  documentManagerPageData.txtFileTest;

            // Send the file path to the file input element
            //fileInput.SendKeys("C:\\Users\\AtchuthanSoorasangar\\Documents\\TestAutomation\\TestDocFiles\\testJpg.jpg");
            //fileInput.SendKeys(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\net6.0", "TestDocFiles\\testJpg.jpg"));

            string relativeFilePath = documentMangerPageData.relativeStringPathToTestDoc;

            // Get the full absolute path to the file
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string absoluteFilePath = Path.GetFullPath(Path.Combine(baseDirectory.Replace(documentMangerPageData.relativePathStringToBeReplaced, ""), relativeFilePath));

            fileInput.SendKeys(absoluteFilePath);

            return this;
        }

        public IWebElement CloseDocumentUploaderPopupFromDocumentManager(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//*[contains(@id,'CloseButton')]"));
        }

        public DocumentManagerPage SearchForDocumentInDocumentManagerTable(IWebDriver driver, string itemToSearch)
        {
            var searchDocumentMan = driver.FindElement(By.XPath("//*[contains(@id,'SearchTextbox')]"));
            //searchDocumentMan.Click();
            searchDocumentMan.Clear();
            searchDocumentMan.SendKeys(itemToSearch);
            searchDocumentMan.SendKeys(Keys.Enter);
            return this;
        }


        public DocumentManagerPage FindDocumentInDocumentManagerTable(IWebDriver driver)
        {
            var table = driver.FindElement(By.XPath(documentMangerPageData.findResultsTableForDocumentManagerByXpath));

            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));

            string searchTextForDoucumentManagerTable = "testJpg";

            // Flag to indicate if the item was found in the table
            documentMangerPageData.isItemFoundInDocumentManagerTable = false;

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
                        documentMangerPageData.isItemFoundInDocumentManagerTable = true;
                        column.Click();
                        break;
                    }
                }

                if (documentMangerPageData.isItemFoundInDocumentManagerTable)
                {
                    // Item found in the table
                    break;
                }
            }

            return this;
        }
    }
}
