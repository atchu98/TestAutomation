using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.TestData
{
    public class LoginTestData
    {
        

        public string baseloginURL = "https://dev6130.mestec.net";
        public string username = "testatchu";
        public string password = "Dell1234";
        

        public string loginURL = "/Login.aspx";
        public string loginWithMestecButtonByID = "btnshowMestec";
        public string loginWithAzureADFieldByID = "btnshowAAD";
        public string usernameFieldByID = "txtUser";
        public string passwordFieldByID = "txtPassword";
        public string loginButtonFieldByID = "loginbutton";
        public string checkAlreadyLoggedInButtonXpath = "//button[text()='Yes']";
        
        public string failedLoginResponse = "Login Failed. Either:\r\n\r\n- The credentials you have entered are incorrect" +
            "\r\n- The user account is locked (you may have exceeded the maximum failed login attempts)" +
            "\r\n- The user account is not licensed\r\n- The user account is federated with Azure AD\r\n- " +
            "You are attempting to log in to a non-trusted device when your account is not permitted\r\n\r\n" +
            "Please contact your system administrator.";

        public string failedLoginFieldByID = "lblError";






    }
}
