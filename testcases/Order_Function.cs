using Assignment02.actions;
using Assignment02.actions.commons;
using Assignment02.reporter;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Assignment02.testcases
{
    [TestFixture]
    class Order_Function : WebDriverManagers
    {
        IWebDriver driver;
        WomenPageObject womenPage;
        HomePageObject homePage;
       
      
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            common.InitReportDirection();
            HtmlReporter.CreateReport(common.REPORT_HTML_FILE);
            HtmlReporter.CreateTest(TestContext.CurrentContext.Test.ClassName);
        }
        [SetUp]
        public void Setup()
        {          
            driver = CreateBrowserDriver("chrome");
            driver.Navigate().GoToUrl(" http://automationpractice.com/index.php");
            HtmlReporter.CreateNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.MethodName);
            homePage = PageGeneratorManager.GetHomePage(driver);
            
        }
        [TestCase("2","L","White")]
        public void Test_01_Verify_Order_Function(string index, string size, string color)
        {
            homePage.HoverToWomenLink();
            womenPage = homePage.ClickToTopsMenu();
            womenPage.HoverToProductByIndex(index);
            womenPage.ClickToMoreButtonByIndexProduct(index);
            womenPage.ClickUpButton();
            womenPage.SelectSizeByText(size);
            womenPage.SelectColorByText(color);
            womenPage.ClickAddToCartButton();
            womenPage.ClickProccedToCheckout1Button();
            Assertion.Equals(womenPage.GetColorProductAtDescription(),color,"Color description is fail", "Color description is true");
            Assertion.Equals(womenPage.GetSizeProductAtDescription(),size, "Size description is fail", "Size description is true");
            womenPage.ClickProccedToCheckout2Button();
            Assertion.True(womenPage.IsUserRequiredLogin(),"Login Page isn't displayed", "Login Page is displayed");

        }
        [TestCase("2")]
        public void Test02_Verify_Wishlist_Only_Work_After_Login(string index)
        {
            homePage.HoverToWomenLink();
            womenPage = homePage.ClickToTopsMenu();
            womenPage.HoverToProductByIndex(index);
            womenPage.ClickAddToWishlistLinkByIndex(index);
            Assertion.True(womenPage.IsErrorMessageDisplayed(),"Wishlist error isn't displayed", "Wishlist error is display");
           
        }

        [TearDown]
        public void Close_Browser()
        {
          driver.Quit();
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            HtmlReporter.flush();
        }
        public static int RandomNumber()
        {
            Random rand = new Random();
            return rand.Next(1,10000);
        }

    }
}