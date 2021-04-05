using Assignment02.interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment02.actions
{
    class MyAccountPageObject: WebDriverBase
    {
        IWebDriver driver;
        public MyAccountPageObject(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        internal string GetWelcomeMessage()
        {
            WaitForElementVisible(MyAccountPageUI.WELCOME_ACCOUNT_MESSAGE);
            return GetElementText(MyAccountPageUI.WELCOME_ACCOUNT_MESSAGE);
        }

        internal void HoverToWomenLink()
        {
            WaitForElementVisible(MyAccountPageUI.WOMEN_LINK);
            HoverToElement(MyAccountPageUI.WOMEN_LINK);
        }

        internal WomenPageObject ClickToTopsMenu()
        {
            WaitForElementVisible(MyAccountPageUI.TOPS_MENU);
            HoverAndClickToElement(MyAccountPageUI.TOPS_MENU);
            return PageGeneratorManager.GetWomenPage(driver);
        }

        
    }
}
