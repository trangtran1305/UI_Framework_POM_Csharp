using Assignment02.actions;
using Assignment02.actions.commons;
using Assignment02.reporter;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;

namespace Assignment02.testcases
{
    [TestFixture]
    class Register_Function : WebDriverManagers
    {
        IWebDriver driver;
        HomePageObject homePage;
        RegisterAndLoginPageObject registerPage;
        MyAccountPageObject myAccountPage;
       
      
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
            registerPage = homePage.ClickToSignInLink();
        }

        [TestCase("changtran{0}@gmail.com", "Mrs","Trang", "Tran","12345678", "13", "5","1999", "NashTech", "Ha Noi", "Ho Chi Minh",
        "Ha Noi", "Texas","00000", "I'm a wonder woman", "04842518", "0389540405", "abc")]
        public void Test01_Verify_Register_Successfully_(string email, string gender, string firstName, string lastName, string passwd,
        string day, string month, string year, string company, string address1, string address2, string city, string state, string zip,
        string addInfo, string homephone, string mobilephone, string alias)
        {
            //Register            
            registerPage.SenkeyToRegisterEmailTextbox(String.Format(email, RandomNumber()).ToString());
            registerPage.ClickToCreateAccountButton();
            registerPage.ClickToGenderRadio(gender);
            registerPage.SenkeyToFirstNameTextbox(firstName);
            registerPage.SenkeyToLastNameTextbox(lastName);
            registerPage.SenkeyToPasswordTextbox(passwd);
            registerPage.SelectDayDropdownList(day);
            registerPage.SelectMonthDropdownList(month);
            registerPage.SelectYearDropdownList(year);
            registerPage.CheckToNewsletterCheckbox();
            registerPage.SendkeyCompanyTextbox(company);
            registerPage.SendkeyAddress1Textbox(address1);
            registerPage.SendkeyAddress2Textbox(address2);
            registerPage.SendkeyCityTextbox(city);
            registerPage.SelectStateDropDownList(state);
            registerPage.SendkeyZipTextbox(zip);
            registerPage.SendkeyAddInformTextarea(addInfo);
            registerPage.SendkeyHomephoneTextbox(homephone);
            registerPage.SendkeyMobilephoneTextbox(mobilephone);
            registerPage.SendkeyAliasTextbox(alias);
            myAccountPage = registerPage.ClickToRegisterButton();
            Assertion.Equals(myAccountPage.GetWelcomeMessage(),
           "Welcome to your account. Here you can manage all of your personal information and orders.","Register fail", "Register successfully!");           
        }

       [TestCase("changkobuchi")]
        public void Test02_Verify_Invalid_Email_Address_Error(string invalidEmail)
        {
            registerPage.SenkeyToRegisterEmailTextbox(invalidEmail);
            registerPage.ClickToCreateAccountButton();
            Assertion.Constains(registerPage.GetErrorMessage(), "Invalid email address.", "Error email message isn't displayed", "Error email message is displayed");
        }

        [TestCase("changtran{0}@gmail.com", "Mrs", "", "13", "5", "1999", "NashTech", "-", "I'm a wonder woman", "04842518","")]
        public void Test03_Verify_Error_Message_For_Mandatory_Field(string email1, string gender, string email2, 
        string day, string month, string year, string company, string country, string addInfo, string homephone, string alias)
        {
            //Register            
            registerPage.SenkeyToRegisterEmailTextbox(String.Format(email1, RandomNumber()).ToString());
            registerPage.ClickToCreateAccountButton();
            registerPage.ClickToGenderRadio(gender);
            registerPage.SendkeyToEmail2Textbox(email2);
            registerPage.SelectDayDropdownList(day);
            registerPage.SelectMonthDropdownList(month);
            registerPage.SelectYearDropdownList(year);
            registerPage.CheckToNewsletterCheckbox();
            registerPage.SendkeyCompanyTextbox(company);
            registerPage.SelectCountryDropDownList(country);
            registerPage.SendkeyAddInformTextarea(addInfo);
            registerPage.SendkeyHomephoneTextbox(homephone);
            registerPage.SendkeyAliasTextbox(alias);
            registerPage.ClickToRegisterButton();
            Assertion.True(registerPage.IsErrorsAtMandatoryFieldsDisplayed(), "Errors for Mandatory fields isn't displayed", "Errors for Mandatory fields is displayed");
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