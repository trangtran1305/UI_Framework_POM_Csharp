using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment02.interfaces
{
    class RegisterAndLoginPageUI
    {

        public static readonly string EMAIL_CREATE_TEXTBOX = "//input[@id='email_create']";
        public static readonly string CREATE_ACCOUNT_BUTTON = "//button[@id='SubmitCreate']";
        public static readonly string EMAIL_LOGIN_TEXTBOX = "//input[@id='email']";
        public static readonly string PASSWORD_LOGIN_TEXTBOX = "//input[@id='passwd']";
        public static readonly string SIGN_IN_BUTTON = "//button[@id='SubmitLogin']";
        public static readonly string DYNAMIC_GENDER_RADIO = "//div[@class='radio-inline' and contains(string(),'{0}.')]";
        public static readonly string FIRSTNAME_TEXTBOX = "//input[@id='customer_firstname']";
        public static readonly string LASTNAME_TEXTBOX = "//input[@id='customer_lastname']";
        public static readonly string PASSWORD_TEXTBOX = "//input[@id='passwd']";
        public static readonly string EMAIL_TEXTBOX = "//input[@id='email']";
        public static readonly string DAY_DROPDOWNLIST = "//select[@id='days']";
        public static readonly string MONTH_DROPDOWNLIST = "//select[@id='months']";
        public static readonly string YEAR_DROPDOWNLIST = "//select[@id='years']";
        public static readonly string NEWLETTER_CHECKBOX = "//input[@id='newsletter']";
        public static readonly string SPECIALOFFERS_CHECKBOX = "//input[@id='optin']";   
        public static readonly string COMPANY_TEXTBOX = "//input[@id='company']";
        public static readonly string ADDRESS1_TEXTBOX = "//input[@id='address1']";
        public static readonly string ADDRESS2_TEXTBOX = "//input[@id='address2']";
        public static readonly string CITY_TEXTBOX = "//input[@id='city']";
        public static readonly string STATE_CHECKBOX = "//select[@id='id_state']";
        public static readonly string ZIP_TEXTBOX = "//input[@id='postcode']";
        public static readonly string COUNTRY_CHECKBOX = "//select[@id='id_country']";
        public static readonly string ADDINFOR_TEXTAREA = "//textarea[@id='other']";
        public static readonly string HOMEPHONE_TEXTBOX = "//input[@id='phone']";
        public static readonly string MOBILEPHONE_TEXTBOX = "//input[@id='phone_mobile']";
        public static readonly string ALIAS_TEXTBOX = "//input[@id='alias']";
        public static readonly string REGISTER_BUTTON = "//button[@id='submitAccount']";
        public static readonly string EMAIL_ERROR_MESSAGE = "//div[@class='alert alert-danger']//li";
        public static readonly string MANDATORY_FIELDS_ERROR_MESSAGE = "//p[text()='There are 10 errors']/parent::div[@class='alert alert-danger']//li";

    }
}
