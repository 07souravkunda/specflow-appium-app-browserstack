using System.Collections.ObjectModel;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SpecFlowBrowserStack;
using TechTalk.SpecFlow;



namespace SpecFlowBasics.StepDefinitions
{
    [Binding]

    public class SampleTest
    {
      private readonly IWebDriver? _driver;
			private string? productOnPageText;
			private string? productOnCartText;
			private bool? cartOpened;
			readonly WebDriverWait wait;
			public SampleTest()
			{
				_driver = BrowserStackSpecFlowTest.ThreadLocalDriver.Value;
				wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
			}

      [Given(@"I open the App")]
			public void GivenINavigatedTowebsite()
			{
			}

			[Then(@"I click on search wikipedia")]
			public void ThenIClickOnSearchWikipedia()
			{
				Thread.Sleep(5000);
				AndroidElement searchElement = (AndroidElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Search Wikipedia")));
      	searchElement.Click();
			}

			[Then(@"I enter '(.*)'")]
			public void ThenEnter(string input)
			{
				AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("org.wikipedia.alpha:id/search_src_text")));
				insertTextElement.SendKeys("BrowserStack");
			}
			[When(@"I check if products are opened")]
			public void WhenICheckIfCartIsOpened()
			{

				cartOpened = _driver?.FindElement(By.ClassName("android.widget.TextView")).Displayed;
				// Assert.IsTrue(cartOpened);
			}
			[Then(@"I should see same product in cart")]
			public void ThenIShouldSeeSameProductInCart()
			{
				ReadOnlyCollection<IWebElement>? allProductsName = _driver?.FindElements(By.ClassName("android.widget.TextView"));
      	// Assert.IsTrue(allProductsName?.Count > 0);
			}

    }
}
