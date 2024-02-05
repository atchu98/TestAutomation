using BoDi;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Drivers
{
    public class Drivers
    {
        private readonly IObjectContainer _container;

        public Drivers(IObjectContainer container)
        {
            _container = container;
        }

        public void StartDriver()
        {
            //IWebDriver driver = new ChromeDriver();

            IWebDriver driver = new EdgeDriver();

            driver.Manage().Window.Maximize();

            // Launch browser
            _container.RegisterInstanceAs<IWebDriver>(driver);

            //    // store driver
        }
    }
}
