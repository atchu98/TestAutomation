using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.TestData
{
    public class SearchPageData
    {
        public string searchPageURL = "/#/menuitem/-3558";
        public string searchPageTitleId = "pageTitle";
        public string searchPageTitle = "Search";
        public string shiftBefore;
        public string shiftAfter;
        public string findOutWhatShiftImOnByID = "lblShift";
        public string userMenuButtonByID = "menuOptionsLabel";
        public string changeShiftLinkText = "Change Shift";
        public string findShiftTableInUserMenuByXpath = "//*[contains(@id,'ShiftGrid')]/div[2]";
        public string findUserShiftTableByTagName = "tr";
        public string getAttributeUsedToGetRowDetailsFromTable = "class";
        public string checkForAnyAttributedWithClassNameContaining = "selected";
        public string selectTeamShiftConfirmationButtonOnChangeShiftByXpath = "//span[text()='Select Team Shift']";
        public string menuSearchTextById = "menusearchtext";
        public string menuSearchTextEnterButtonById = "searchbutton";


        public string documentManagerSearchItem = "Document Manager";
        public string dataFileManagerSearchItem = "Data File Manager";
    }
}
