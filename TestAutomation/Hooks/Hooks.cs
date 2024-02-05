using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V112.CSS;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using TestAutomation.TestData;
using TestAutomation.Utilities;
using TestAutomation.Drivers;
namespace TestAutomation.Hooks
{
    [Binding]
    public sealed class Hooks : ExtentReport
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        
        private IWebDriver driver;
       
        private readonly IObjectContainer _container;
        

        public Hooks(IObjectContainer container)
        {
            _container = container;
            
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running Before Test Run");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {

            Console.WriteLine("Running After Test Run");
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running Before Feature");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running After Feature");

        }

        //[BeforeScenario("@Smoke", Order = 1)]
        //public void BeforeScenarioWithTag(ScenarioContext scenarioContext)
        //{
        //}

        //[BeforeScenario("@Sanity", Order = 2)]
        //public void BeforeScenarioWithTag1(ScenarioContext scenarioContext)
        //{
        //}
        //[BeforeScenario(Order = 3)]
        //public void BeforeScenarioWithTag2(ScenarioContext scenarioContext)
        //{
        //}



        [BeforeScenario]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {

            //IWebDriver driver = new ChromeDriver();

            IWebDriver driver = new EdgeDriver();

            driver.Manage().Window.Maximize();

            // Launch browser
            _container.RegisterInstanceAs<IWebDriver>(driver);

            //    // store driver
            




            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            //_scenario = _extentReports.CreateTest(TestContext.CurrentContext.Test.Name);

            var browserName = ((IHasCapabilities)driver).Capabilities.GetCapability("browserName").ToString();
            var browserVersion = ((IHasCapabilities)driver).Capabilities.GetCapability("browserVersion").ToString();
            ExtentReportInitBrowserData(browserName, browserVersion);



        }
        

         


        [AfterScenario]
        public void AfterScenario()
        {
            
            //Close Browser
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null) { driver.Quit(); }

        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var driver = _container.Resolve<IWebDriver>();
            Console.WriteLine("Running After Step");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;






            //When Scenario Passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
            }

            //When Scenario Fail
            else if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, scenarioContext)).Build());

                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, scenarioContext)).Build());

                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, scenarioContext)).Build());

                }
            }
            

            
        }
    }
}