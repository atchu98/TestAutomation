using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.TestData
{
    public class DocumentManagerPageData
    {
        public string documentManagerPageUrl = "/#/menuitem/-3509";
        //public static string dir = AppDomain.CurrentDomain.BaseDirectory;
        //public static string txtFileTest = dir.Replace("bin\\Debug\\net6.0", "TestDocFiles\\MESTECtxtTest.txt");

        public string documentManagerUploadButtonByXpath = "//button[text()='Upload Document']";
        public string relativePathStringToBeReplaced = "bin\\Debug\\net6.0";
        public string relativeStringPathToTestDoc = "TestDocFiles\\testJpg.jpg";
        public string uploadFileToDocumentMAnagerTableByXpath = "//*[contains(@id,'Upload')]";
        public string documentManagerTableFileInputByName = "files";
        public bool isItemFoundInDocumentManagerTable;
        public string findResultsTableForDocumentManagerByXpath = "//*[contains(@id,'DocumentsGrid')]/div[3]/table";
        public string documentNameToSearch = "testJpg";
    }
}
