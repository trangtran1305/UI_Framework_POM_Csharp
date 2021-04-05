
using Assignment02.reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Linq;
using WebDriverManager.DriverConfigs.Impl;

namespace Assignment02.actions
{
    class WebDriverManagers
    {
		private static IWebDriver _driver;

       	public static IWebDriver CreateBrowserDriver(String Value)
		{
			if (Value.SequenceEqual("firefox"))
			{
				new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
				_driver = new FirefoxDriver();
			}
			else if (Value.SequenceEqual("chrome"))
			{

				new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
				_driver = new ChromeDriver();
			}
			else if (Value.SequenceEqual("edge"))
			{
				new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
				_driver =  new EdgeDriver(); 
			}
			_driver.Manage().Window.Maximize();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			return _driver;
		}
		
		
	}
}
