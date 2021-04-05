using Assignment02.interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment02.actions
{
    class HomePageObject : WebDriverBase
    {
        IWebDriver driver;
        public HomePageObject(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        internal RegisterAndLoginPageObject ClickToSignInLink()
        {
            WaitForElementClickable(HomePageUI.SIGN_IN_LINK);
            ClickToElement(HomePageUI.SIGN_IN_LINK);
            return PageGeneratorManager.GetLoginPage(driver);
        }

        internal void HoverToWomenLink()
        {
            WaitForElementVisible(HomePageUI.WOMEN_LINK);
            HoverToElement(HomePageUI.WOMEN_LINK);
        }

        internal WomenPageObject ClickToTopsMenu()
        {
            WaitForElementVisible(HomePageUI.TOPS_MENU);
            HoverAndClickToElement(HomePageUI.TOPS_MENU);
            return PageGeneratorManager.GetWomenPage(driver);
        }

        
    }
}
