using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TestAutomation.TestData;
using TestAutomation.Pages;

namespace TestAutomation.Utilities
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;
        private static bool dataAccepted = false;


        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public static void ExtentReportInit()
        {
            
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();


            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            // Change this from hardcoded to runtime
            //_extentReports.AddSystemInfo("Application", "Mestec");
            //_extentReports.AddSystemInfo("Browser", "");
            _extentReports.AddSystemInfo("Device", Environment.MachineName);
            _extentReports.AddSystemInfo("OS", Environment.OSVersion.ToString());
            
            


        }

        public static void ExtentReportInitBrowserData(string browserName, string browserVersion)
        {
            

            if (!dataAccepted)
            {
                LoginTestData loginData = new LoginTestData();
                int stringLength = loginData.baseloginURL.Length - 12;
                _extentReports.AddSystemInfo("Application", loginData.baseloginURL.Substring(8, stringLength));
                _extentReports.AddSystemInfo("Browser", browserName);
                _extentReports.AddSystemInfo("Browser Version", browserVersion);

                // Set the flag to indicate that data has been accepted
                dataAccepted = true;
            }
            


        }

        





            public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public string addScreenShot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot) driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title+".png");
            screenshot.SaveAsFile(screenshotLocation,ScreenshotImageFormat.Png);
            return screenshotLocation;
        }

    }
}
