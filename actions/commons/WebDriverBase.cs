using Assignment02.reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Assignment02.actions
{
    class WebDriverBase
    {
		public IWebDriver driver;
		public WebDriverBase(IWebDriver driver)
        {
			this.driver = driver;
        }
		public void OpenUrl(String url)
		{
			try
			{
				driver.Navigate().GoToUrl(url);
				HtmlReporter.Pass("Open Url: "+ url.ToString());
            }
            catch (Exception ex)
			{ 
				HtmlReporter.Fail("Can not open Url: "+url.ToString());
				throw ex;
			}
		}
		public string CreateScreenshot()
		{
			ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
			Screenshot screenshot = screenshotDriver.GetScreenshot();
			string path = common.SCREENSHOT_PNG_FILE;
			screenshot.SaveAsFile(path);
			return path;
		}
		public void ClickToElement(String locator)
		{
			try
			{
				FindElementByXpath(locator).Click();
				HtmlReporter.Pass("Click to element [" + locator.ToString() + "]");
			}
			catch (Exception ex)
			{
				string path = CreateScreenshot();
				HtmlReporter.Fail("Cannot senkey to element [" + locator.ToString() + "]", ex, path);
				throw ex;
			}
		}
		public void ClickToElement(String locator, string index)
		{
			try
			{
				FindElementByXpath(String.Format(locator, index)).Click();
				HtmlReporter.Pass("Click to element [" + String.Format(locator, index).ToString() + "]");
			}
			catch (Exception ex)
			{
				string path = CreateScreenshot();
				HtmlReporter.Fail("Cannot senkey to element [" + String.Format(locator, index).ToString() + "]", ex, path);
				throw ex;
			}
		}
		public void SendKeyToElement(string locator, string value)
		{
			try
			{
				FindElementByXpath(locator).Clear();
				FindElementByXpath(locator).SendKeys(value);
				HtmlReporter.Pass("Senkeys to element [" + locator.ToString() + "]");
			}
			catch (Exception ex)
			{
				{
					string path = CreateScreenshot();
					HtmlReporter.Fail("Cannot senkey to element [" + locator.ToString() + "]", ex, path);
					throw ex;
				}
			}
		}
		public void ClickToElement(IWebElement element)
		{
			try
			{
				element.Click();
				HtmlReporter.Pass("Click to element [" + element.ToString() + "]");
			}
			catch (Exception ex)
			{
				HtmlReporter.Fail("Can't click to element [" + element.ToString() + "]");
				throw ex;
			}
		}

		public void SendKeyToElement(IWebElement element, String value)
		{
			try
			{
				element.Clear();
				element.SendKeys(value);
				HtmlReporter.Pass("Click to element [" + element.ToString() + "]");
			}
			catch (Exception ex)
			{
				HtmlReporter.Fail("Can't click to element [" + element.ToString() + "]"); ;
				throw ex;
			}
		}
		public void SelectValueInDropdown(String locator, String value)
		{
			try
			{
				select = new SelectElement(FindElementByXpath(locator));
				select.SelectByValue(value);
				HtmlReporter.Pass("Select dropdown by value" + value + " from element [" + locator.ToString() + "]");
			}
			catch (Exception ex)
			{
				string path = CreateScreenshot();
				HtmlReporter.Fail("Cannot select dropdown by value" + value + " from element [" + locator.ToString() + "]", ex, path);
				throw ex;

			}
		}
		public void SelectByTextInDropdown(String locator, String value)
		{
			try
			{
				select = new SelectElement(FindElementByXpath(locator));
				select.SelectByText(value);
				HtmlReporter.Pass("Select dropdown by text" + value + " from element [" + locator.ToString() + "]");
			}
			catch (Exception ex)
			{
				string path = CreateScreenshot();
				HtmlReporter.Fail("Cannot select dropdown by text" + value + " from element [" + locator.ToString() + "]", ex, path);
				throw ex;

			}
		}

		public String GetSelectItemInDropdown(String locator)
		{
			select = new SelectElement(FindElementByXpath(locator));
			return select.SelectedOption.Text;

		}

		public void SleepInSeconds(int time)
		{
			try
			{
				Thread.Sleep(time);
			}
			catch (ThreadInterruptedException e)
			{
				e.StackTrace.ToString();

			}
		}

		public void SelectItemInDropDown(String parentLocator, String ItemsLocator, String expectedItem)
		{

			explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByXpath(parentLocator)));
			FindElementByXpath(parentLocator).Click();
			SleepInSeconds(1);
			explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(ByXpath(ItemsLocator)));

			elements = FindElementsByXpath(ItemsLocator);

			foreach (IWebElement item in elements)
			{
				if (item.Text.SequenceEqual(expectedItem))
				{

					js.ExecuteScript("arguments[0].scrollIntoView(true);", item);
					SleepInSeconds(2);
					explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(item));
					item.Click();
					SleepInSeconds(2);
					break;
				}
			}

		}
		public void CheckToCheckbox(String locator)
		{
			try
			{
				element = FindElementByXpath(locator);
				if (!element.Selected)
					element.Click();
				HtmlReporter.Pass("Checkbox to element [" + locator.ToString() + "]");
			}
			catch(Exception ex)
            {
				string path = CreateScreenshot();
				HtmlReporter.Fail("Can't checkbox to element [" + locator.ToString() + "]", ex, path);
				throw ex;
			}
		}

		public void UnCheckToCheckbox(String locator)
		{
			element = FindElementByXpath(locator);
			if (element.Selected)
				element.Click();
		}
		public void ClickToRadio(string locator, string gender)
		{
			try
			{
				element = FindElementByXpath(String.Format(locator, gender));
				if (!element.Selected)
					element.Click();
				HtmlReporter.Pass("Click to radio [" + locator.ToString() + "]");
			}
			catch(Exception ex)
            {
				string path = CreateScreenshot();
				HtmlReporter.Fail("Can't click to radio [" + locator.ToString() + "]", ex, path);
				throw ex;
			}
		}

		public void HoverToElement(string locator)
		{
			try
			{
				Actions action = new Actions(driver);
				action.MoveToElement(FindElementByXpath(locator)).Perform();
				HtmlReporter.Pass("Hover to element [" + locator.ToString() + "]");

			}
			catch(Exception ex)
            {
				string path = CreateScreenshot();
				HtmlReporter.Fail("Can't hover to element [" + locator.ToString() + "]", ex, path);
				throw ex;
			}
		}
		public void HoverToElement(string locator, string index)
		{
			try
			{
				Actions action = new Actions(driver);
				action.MoveToElement(FindElementByXpath(String.Format(locator, index))).Perform();
				HtmlReporter.Pass("Hover to element [" + String.Format(locator, index).ToString() + "]");

			}
			catch (Exception ex)
			{
				string path = CreateScreenshot();
				HtmlReporter.Fail("Can't hover to element [" + String.Format(locator, index) + "]", ex, path);
				throw ex;
			}
		}
		public void HoverAndClickToElement(string locator)
		{
			try
			{
				Actions action = new Actions(driver);
				action.MoveToElement(FindElementByXpath(locator)).Click().Perform();
				HtmlReporter.Pass("Hover and click to element [" + String.Format(locator).ToString() + "]");
			}
            catch (Exception ex)
            {
				string path = CreateScreenshot();
				HtmlReporter.Fail("Can't hover and click to element [" + String.Format(locator) + "]", ex, path);
				throw ex;
			}
		}

		public int CountElementNumber(string locator)
		{
			elements = FindElementsByXpath(locator);
			return elements.Count();
		}

		public bool IsElementDisplayed(string locator)
		{
			try
			{
				element = FindElementByXpath(locator);
				return element.Displayed;
			}
			catch (NoSuchElementException e)
			{
				e.StackTrace.ToString();
				return false;
			}
		}

		public void AcceptAlert()
        {
			driver.SwitchTo().Alert().Accept();
		}

		public void CancelAlert()
		{
			driver.SwitchTo().Alert().Dismiss();
		}

		public void SendkeyToAlert(String value)
		{
			driver.SwitchTo().Alert().SendKeys(value);
		}
		public string GetTextAlert()
		{
			try
			{
				return driver.SwitchTo().Alert().Text;
				HtmlReporter.Pass("Get text alert");
			}
			catch(Exception e)
            {
				HtmlReporter.Fail("Can't get text from alert");
				return e.Message;
            }
		}
		
		public void WaitForElementVisible(string locator)
		{
			explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(longtimeout));
			explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ByXpath(locator)));

		}
		public void WaitForElementExists(string locator)
		{
			explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(longtimeout));
			explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(ByXpath(locator)));

		}
		public void WaitForElementVisible(string locator, string value)
		{
			explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(longtimeout));
			explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ByXpath(String.Format(locator, value))));

		}

		public void WaitForElementInvisible(string locator)
		{
			explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(longtimeout));
			explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(ByXpath(locator)));
		}
		public void WaitForElementClickable(string locator)
		{
			explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(longtimeout));
			explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByXpath(locator)));

		}
		public void WaitForAlertPresence()
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

		}

		// 2 tab
		public void SwitchToWindowByID(String parentID)
		{
			HashSet<string> allID = driver.WindowHandles.ToHashSet();
			foreach (string id in allID)
			{
				if (!id.SequenceEqual(parentID)){
					driver.SwitchTo().Window(id);
				}
				break;
			}
		}

		// nhieu hon 2 tab
		public void SwitchToWindowByTitle(string title)
		{
			HashSet<string> allID = driver.WindowHandles.ToHashSet();
			foreach (string id in allID)
			{
				driver.SwitchTo().Window(id);
				if (driver.Title.SequenceEqual(title)){
					break;
				}
			}
		}

		public void CloseAllWindowsWithoutParent(string parentID)
		{
			HashSet<string> allID = driver.WindowHandles.ToHashSet();
			foreach (String id in allID)
			{
				if (!id.SequenceEqual(parentID))
					driver.SwitchTo().Window(id);
				driver.Close();
			}
			driver.SwitchTo().Window(parentID);
		}

		public By ByXpath(string locator)
		{
			return By.XPath(locator);

		}

		public IWebElement FindElementByXpath(string locator)
        {
			try
			{
				return driver.FindElement(ByXpath(locator));
				HtmlReporter.Pass("Find element [" + locator.ToString() + "]");
			}
			catch(Exception ex)
            {
				HtmlReporter.Fail("Can't find element [" + locator.ToString() + "]");
				throw ex;
            }
		}

		public IList<IWebElement> FindElementsByXpath(String locator)
		{
			return driver.FindElements(ByXpath(locator));
		}
				

		public String GetElementText(String locator)
		{
			return driver.FindElement(ByXpath(locator)).Text;
		}
		public String GetElementText(IWebElement element)
		{
			return element.Text;
		}
		public String GetCurrentUrl()
		{
			return driver.Url;
		}

		public String GetPageTitle()
		{
			return driver.Title;
		}
		public void Forward()
		{
			driver.Navigate().Forward();
		}

		public void Refresh()
		{
			driver.Navigate().Refresh();
		}

		public void OverrideTimeout(long timeout)
		{
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
		}

		// đè lại timeout=shorttime khi không tìm thấy element trong DOM,sau đó lại đè lại timeout=longtime ban đầu
		public bool IsElementUndisplayed(String locator)
		{
			OverrideTimeout(shorttimeout);
			elements = driver.FindElements(ByXpath(locator));
			if (elements.Count() == 0)
			{
				OverrideTimeout(longtimeout);
				return true;
			}
			else if (elements.Count() > 0 && !elements.ElementAt(0).Displayed)
			{
				OverrideTimeout(longtimeout);
				return true;
			}
			else
			{
				OverrideTimeout(longtimeout);
				return false;
			}

		}

		public bool IsElementEnabled(String locator)
		{
			return FindElementByXpath(locator).Enabled;
		}

		public bool IsElementSelected(String locator)
		{
			return FindElementByXpath(locator).Selected;
		}

		public void SwitchToFrame(String locator)
		{
			element = FindElementByXpath(locator);
			driver.SwitchTo().Frame(element);
		}

		public void SwitchToDefaultContent()
		{

			driver.SwitchTo().DefaultContent();
		}
        public string GetTextAtAlert()
        {
			var alert = driver.SwitchTo().Alert();

			return alert.Text;
        }

		// Browser
		public Object ExecuteForBrowser(String javaSript)
		{
			js = (IJavaScriptExecutor)driver;
			return js.ExecuteScript(javaSript);
		}

		public bool VerifyTextInInnerText(String textExpected)
		{
			js = (IJavaScriptExecutor)driver;
			String textActual = (String)js
					.ExecuteScript("return document.documentElement.innerText.match('" + textExpected + "')[0]");
			Console.WriteLine("Text actual = " + textActual);
			return textActual.SequenceEqual(textExpected);
		}

		public void ScrollToBottomPage()
		{
			js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
		}

		public void NavigateToUrlByJS(String url)
		{
			js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("window.location = '" + url + "'");
		}

		// Element
		public void HighlightElement(String locator)
		{
			element = FindElementByXpath(locator);
			String originalStyle = element.GetAttribute("style");
			js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, "style",
					"border: 5px solid red; border-style: dashed;");
			try
			{
				Thread.Sleep(2000);
			}
			catch (ThreadInterruptedException e)
			{
				e.StackTrace.ToString();
			}
			js.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, "style", originalStyle);

		}

		public void ClickToElementByJS(String locator)
		{
			element = FindElementByXpath(locator);
			js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("arguments[0].click();", element);
		}

		public void ScrollToElement(String locator)
		{
			element = FindElementByXpath(locator);
			js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
		}
		public void ScrollToElement(String locator, string index)
		{
			element = FindElementByXpath(String.Format(locator, index));
			js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
		}

		public void SendkeyToElementByJS(String locator, String value)
		{
			element = FindElementByXpath(locator);
			js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("arguments[0].setAttribute('value', '" + value + "')", element);
		}

		public void RemoveAttributeInDOM(IWebDriver driver, String locator, String attributeRemove)
		{
			element = FindElementByXpath(locator);
			js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("arguments[0].removeAttribute('" + attributeRemove + "');", element);
		}


		public bool IsImageDisplayed(IWebElement image)
		{
			js = (IJavaScriptExecutor)driver;
			Boolean ImagePresent = (Boolean)((IJavaScriptExecutor)driver)
					.ExecuteScript("return arguments[0].complete && typeof arguments[0].naturalWidth !="
							+ " \"undefined\" && arguments[0].naturalWidth > 0", image);
			if (!ImagePresent)
				return false;
			else
				return true;
		}


		// Sort ascending
		public bool IsDataSortedAscending(string locator)
		{

			List<int> list = new List<int>();

			IList<IWebElement> elementList = driver.FindElements(By.XPath(locator));
			foreach (IWebElement element in elementList)
			{
				list.Add(Convert.ToInt32(element.Text));
			}
			List<int> sortedList = new List<int>();
			foreach (var item in list)
			{
				sortedList.Add(item);

			}
			sortedList.Sort();
			return sortedList.SequenceEqual(list);
		}
		// Sort descending
		public bool IsDataSortedDescending(string locator)
		{

			List<int> list = new List<int>();

			IList<IWebElement> elementList = driver.FindElements(By.XPath(locator));
			foreach (IWebElement element in elementList)
			{
				list.Add(Convert.ToInt32(element.Text));
			}
			List<int> sortedList = new List<int>();
			foreach (var item in list)
			{
				sortedList.Add(item);

			}
			sortedList.Sort();
			sortedList.Reverse();
			return sortedList.SequenceEqual(list);
		}
		// Upload_Multiple_File_Rest_Paramemeter
		public void UploadMultipleFiles(string locator,params String[]fileNames)
		{
			String fullFileName = "";
			foreach (String file in fileNames)
			{
				fullFileName = fullFileName + "..\\upload_file\\" + file + "\n";
			}

			fullFileName = fullFileName.Trim();
			driver.FindElement(By.XPath(locator)).SendKeys(fullFileName);
		}
		public static int RandomNumber()
		{
			Random rand = new Random();
			return rand.Next(1, 10000);
		}

		private SelectElement select;
		private IJavaScriptExecutor js;
		private IWebElement element;
		IList<IWebElement> elements;
		private WebDriverWait explicitWait;
		private readonly long longtimeout = 30;
		private readonly long shorttimeout = 5;

	}
}
