using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.TestData;

namespace TestAutomation.Pages
{
    public class SearchPage
    {
        private IWebDriver driver;
        SearchPageData searchPageData = new SearchPageData();
        public SearchPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public string GetSearchPageTitle(IWebDriver driver)
        {
            return driver.FindElement(By.Id(searchPageData.searchPageTitleId)).Text;

        }
        public string GetShiftInfo(IWebDriver driver) 
        {
            return driver.FindElement(By.Id(searchPageData.findOutWhatShiftImOnByID)).Text;
        }

        public IWebElement FindTheUserMenuButton(IWebDriver driver) 
        {
            return driver.FindElement(By.Id(searchPageData.userMenuButtonByID));
            
        }

        public IWebElement FindTheChangeShiftButton(IWebDriver driver)
        {
            return driver.FindElement(By.LinkText(searchPageData.changeShiftLinkText));
        }

        public SearchPage ClickOnAnotherShiftThatIsNotSelected(IWebDriver driver) 
        {
            var table = driver.FindElement(By.XPath(searchPageData.findShiftTableInUserMenuByXpath));

            IList<IWebElement> rows = table.FindElements(By.TagName(searchPageData.findUserShiftTableByTagName));
            Console.WriteLine(rows.Count());
            foreach (IWebElement row in rows)
            {

                //bool isRowSelected = row.GetAttribute(searchPageData.getAttributeUsedToGetRowDetailsFromTable).Contains(searchPageData.checkForAnyAttributedWithClassNameContaining);
                bool isRowSelected = Convert.ToBoolean(row.GetAttribute("aria-selected"));
                Console.WriteLine(row.GetAttribute("aria-selected"));

                // Click on the second row if the first row is selected
                if (isRowSelected == false)
                {
                    // Perform any desired actions with the second row
                    // For example, you can click on it using rows[1].Click()
                    row.Click();
                    break;
                }



            }
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(searchPageData.selectTeamShiftConfirmationButtonOnChangeShiftByXpath)).Click();

            return this;
        }

        public SearchPage SearchItemInMenuSearch(IWebDriver driver, string searchmenuKeyWord)
        {
            driver.FindElement(By.Id(searchPageData.menuSearchTextById)).Clear();
            driver.FindElement(By.Id(searchPageData.menuSearchTextById)).SendKeys(searchmenuKeyWord);
            driver.FindElement(By.Id(searchPageData.menuSearchTextEnterButtonById)).Click();
            Thread.Sleep(2500);
            return this;
        }
        
        public IWebElement FindItemFromSearchResults_MenuSearch(IWebDriver driver, string searchmenuKeyWord)
        {
           return driver.FindElement(By.LinkText(searchmenuKeyWord));
        }

    }
}
