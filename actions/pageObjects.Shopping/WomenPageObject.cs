using Assignment02.interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment02.actions
{
    class WomenPageObject : WebDriverBase
    {

        public WomenPageObject(IWebDriver driver) : base(driver)
        {
        }

        internal void HoverToProductByIndex(string index)
        {
            ClickToElement(WomenPageUI.LIST_LINK);
            ScrollToElement(WomenPageUI.DYNAMIC_PRODUCT_NAME, index);
            HoverToElement(WomenPageUI.DYNAMIC_PRODUCT_NAME, index);
        }

        internal void ClickToMoreButtonByIndexProduct(string index)
        {
            // WaitForElementVisible(WomenPageUI.DYNAMIC_MORE_BUTTON, index);
            ClickToElement(WomenPageUI.DYNAMIC_MORE_BUTTON, index);
        }

        internal void ClickUpButton()
        {
            WaitForElementVisible(WomenPageUI.QUANTITY_BUTTON);
            ClickToElement(WomenPageUI.QUANTITY_BUTTON);
        }

        internal void SelectColorByText(string value)
        {
            WaitForElementVisible(WomenPageUI.COLOR_LINK, value);
            ClickToElement(WomenPageUI.COLOR_LINK, value);
        }

        internal void ClickAddToCartButton()
        {
            WaitForElementVisible(WomenPageUI.ADD_TO_CART_BUTTON);
            ClickToElement(WomenPageUI.ADD_TO_CART_BUTTON);
        }

        internal void ClickProccedToCheckout1Button()
        {
            WaitForElementVisible(WomenPageUI.PROCEED_TO_CHECKOUT1_BUTTON);
            ClickToElement(WomenPageUI.PROCEED_TO_CHECKOUT1_BUTTON);
        }

        internal void SelectSizeByText(string value)
        {
            WaitForElementExists(WomenPageUI.SIZE_DROPDOWNLIST);
            SelectByTextInDropdown(WomenPageUI.SIZE_DROPDOWNLIST, value);
        }

        internal object GetColorProductAtDescription()
        {
            WaitForElementVisible(WomenPageUI.COLOR_DESCRIPTION);
            return GetElementText(WomenPageUI.COLOR_DESCRIPTION);
        }

        internal string GetSizeProductAtDescription()
        {
            WaitForElementVisible(WomenPageUI.SIZE_DESCRIPTION);
            return GetElementText(WomenPageUI.SIZE_DESCRIPTION);

        }

        internal void ClickProccedToCheckout2Button()
        {
            WaitForElementVisible(WomenPageUI.PROCEED_TO_CHECKOUT2_BUTTON);
            ClickToElement(WomenPageUI.PROCEED_TO_CHECKOUT2_BUTTON);
        }

        internal bool IsUserRequiredLogin()
        {
            return IsElementDisplayed(WomenPageUI.AUTHENTICATION_TEXT);
        }

        internal void ClickAddToWishlistLinkByIndex(string index)
        {
            WaitForElementVisible(WomenPageUI.DYNAMIC_WISHLIST_LINK, index);
            ClickToElement(WomenPageUI.DYNAMIC_WISHLIST_LINK, index);
        }

        internal bool IsErrorMessageDisplayed()
        {
            WaitForElementVisible(WomenPageUI.ERROR_MESSAGE_WISHLIST);
            return IsElementDisplayed(WomenPageUI.ERROR_MESSAGE_WISHLIST);
        }
    }
}