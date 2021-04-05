using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment02.interfaces
{
    class WomenPageUI
    {
        public static readonly string WELCOME_ACCOUNT_MESSAGE = "//p[@class='info-account']";
        public static readonly string WOMEN_LINK = "//a[text()='Women']";
        public static readonly string TOPS_MENU = "//a[text()='Women']//a[@title='Tops']";
        public static readonly string LIST_LINK = "//a[@title='List']";
        public static readonly string DYNAMIC_PRODUCT_NAME = "//ul[@class='product_list row list']/li[{0}]//a[@class='product-name']";
        public static readonly string DYNAMIC_MORE_BUTTON = "//ul[@class='product_list row list']/li[{0}]//span[text()='More']/parent::a";
        public static readonly string QUANTITY_BUTTON = "//a[contains(@class,'quantity_up')]";
        public static readonly string SIZE_DROPDOWNLIST = "//select[@id='group_1']";
        public static readonly string COLOR_LINK = "//label[contains(text(), 'Color')]/parent::fieldset//a[@name='{0}']";
        public static readonly string ADD_TO_CART_BUTTON = "//span[text()='Add to cart']/parent::button";
        public static readonly string PROCEED_TO_CHECKOUT1_BUTTON = "//span[contains(text(),'Proceed to checkout')]/parent::a";
        public static readonly string SIZE_DESCRIPTION = "//td[@class='cart_description']//a[contains(text(),'Size')]";
        public static readonly string COLOR_DESCRIPTION = "//td[@class='cart_description']//a[contains(text(),'Color')]";
        public static readonly string PROCEED_TO_CHECKOUT2_BUTTON = "//p/a[@title='Proceed to checkout']";
        public static readonly string AUTHENTICATION_TEXT = "//h1[contains(text(),'Authentication')]";
        public static readonly string DYNAMIC_WISHLIST_LINK= "//a[contains(text(),'Add to Wishlist') and @rel='{0}']";
        public static readonly string ERROR_MESSAGE_WISHLIST = "//p[contains(text(),'You must be logged in to manage your wishlist.')]";
    }
}
