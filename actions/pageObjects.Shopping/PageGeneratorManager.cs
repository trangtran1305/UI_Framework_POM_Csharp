using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment02.actions
{
    class PageGeneratorManager
    {
        public static HomePageObject GetHomePage(IWebDriver driver)
        {
            return new HomePageObject(driver);
        }
        public static MyAccountPageObject GetMyAccountPage(IWebDriver driver)
        {
            return new MyAccountPageObject(driver);
        }
        public static RegisterAndLoginPageObject GetLoginPage(IWebDriver driver)
        {
            return new RegisterAndLoginPageObject(driver);
        }
        public static WomenPageObject GetWomenPage(IWebDriver driver)
        {
            return new WomenPageObject(driver);
        }

    }
}
