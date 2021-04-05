using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Assignment02.interfaces;
using System.Linq;
using System.Threading;

namespace Assignment02.actions
{
    class RegisterAndLoginPageObject : WebDriverBase
    {
        IWebDriver driver;
        public RegisterAndLoginPageObject(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        internal void SenkeyToRegisterEmailTextbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.EMAIL_CREATE_TEXTBOX);
            ScrollToElement(RegisterAndLoginPageUI.EMAIL_CREATE_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.EMAIL_CREATE_TEXTBOX, value);
        }

        internal void ClickToCreateAccountButton()
        {
            WaitForElementClickable(RegisterAndLoginPageUI.CREATE_ACCOUNT_BUTTON);
            ClickToElement(RegisterAndLoginPageUI.CREATE_ACCOUNT_BUTTON);
        }
        internal void SenkeyToLoginEmailTextbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.EMAIL_LOGIN_TEXTBOX);
            ScrollToElement(RegisterAndLoginPageUI.EMAIL_LOGIN_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.EMAIL_LOGIN_TEXTBOX, value);
        }
        internal void SenkeyToLoginPasswordTextbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.PASSWORD_LOGIN_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.PASSWORD_LOGIN_TEXTBOX, value);
        }

        internal MyAccountPageObject ClickToSignInButton()
        {
            WaitForElementClickable(RegisterAndLoginPageUI.SIGN_IN_BUTTON);
            ClickToElement(RegisterAndLoginPageUI.SIGN_IN_BUTTON);
            return PageGeneratorManager.GetMyAccountPage(driver);
        }

        internal void ClickToGenderRadio(string gender)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.DYNAMIC_GENDER_RADIO, gender);
            ClickToRadio(RegisterAndLoginPageUI.DYNAMIC_GENDER_RADIO, gender);
        }

        internal void SenkeyToFirstNameTextbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.FIRSTNAME_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.FIRSTNAME_TEXTBOX, value);
        }

        internal void SenkeyToLastNameTextbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.LASTNAME_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.LASTNAME_TEXTBOX, value);

        }
        internal void SenkeyToPasswordTextbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.PASSWORD_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.PASSWORD_TEXTBOX, value);
        }
        internal void SendkeyToEmail2Textbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.EMAIL_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.EMAIL_TEXTBOX, value);
        }


        internal void SelectDayDropdownList(string value)
        {
            ScrollToElement(RegisterAndLoginPageUI.DAY_DROPDOWNLIST);
            SelectValueInDropdown(RegisterAndLoginPageUI.DAY_DROPDOWNLIST, value);
        }
        internal void SelectMonthDropdownList(string value)
        {   
            SelectValueInDropdown(RegisterAndLoginPageUI.MONTH_DROPDOWNLIST, value);
        }

        internal void SelectYearDropdownList(string value)
        {
            SelectValueInDropdown(RegisterAndLoginPageUI.YEAR_DROPDOWNLIST, value);
        }

        internal void CheckToNewsletterCheckbox()
        {
            CheckToCheckbox(RegisterAndLoginPageUI.NEWLETTER_CHECKBOX);
        }

        internal void SendkeyAddress1Textbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.ADDRESS1_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.ADDRESS1_TEXTBOX, value);
        }
        internal void SendkeyAddress2Textbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.ADDRESS2_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.ADDRESS2_TEXTBOX, value);
        }

        
        internal void SendkeyCityTextbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.CITY_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.CITY_TEXTBOX, value);
        }

        internal void SendkeyZipTextbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.ZIP_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.ZIP_TEXTBOX, value);
        }

        internal void SendkeyAddInformTextarea(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.ADDINFOR_TEXTAREA);
            SendKeyToElement(RegisterAndLoginPageUI.ADDINFOR_TEXTAREA, value);
        }

        internal void SelectCountryDropDownList(string value)
        {
           
            ScrollToElement(RegisterAndLoginPageUI.COUNTRY_CHECKBOX);
            SelectByTextInDropdown(RegisterAndLoginPageUI.COUNTRY_CHECKBOX, value);
        }

        internal void SendkeyMobilephoneTextbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.MOBILEPHONE_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.MOBILEPHONE_TEXTBOX, value);
        }
        internal void SendkeyHomephoneTextbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.HOMEPHONE_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.HOMEPHONE_TEXTBOX, value);
        }

        internal void SelectStateDropDownList(string value)
        {           
            SelectByTextInDropdown(RegisterAndLoginPageUI.STATE_CHECKBOX, value);
        }

        internal void SendkeyCompanyTextbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.COMPANY_TEXTBOX);
            ScrollToElement(RegisterAndLoginPageUI.COMPANY_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.COMPANY_TEXTBOX, value);
        }

        internal void SendkeyAliasTextbox(string value)
        {
            WaitForElementVisible(RegisterAndLoginPageUI.ALIAS_TEXTBOX);
            SendKeyToElement(RegisterAndLoginPageUI.ALIAS_TEXTBOX, value);
        }

        internal MyAccountPageObject ClickToRegisterButton()
        {
            WaitForElementClickable(RegisterAndLoginPageUI.REGISTER_BUTTON);
            ClickToElement(RegisterAndLoginPageUI.REGISTER_BUTTON);
            return PageGeneratorManager.GetMyAccountPage(driver);
        }
        internal string GetErrorMessage()
        {
            WaitForElementVisible(RegisterAndLoginPageUI.EMAIL_ERROR_MESSAGE);
            return GetElementText(RegisterAndLoginPageUI.EMAIL_ERROR_MESSAGE);
        }
        internal bool IsErrorsAtMandatoryFieldsDisplayed()
        {
            return IsElementDisplayed(RegisterAndLoginPageUI.MANDATORY_FIELDS_ERROR_MESSAGE)
                   && 
                   CountElementNumber(RegisterAndLoginPageUI.MANDATORY_FIELDS_ERROR_MESSAGE) == 10;
        }


    }
}
