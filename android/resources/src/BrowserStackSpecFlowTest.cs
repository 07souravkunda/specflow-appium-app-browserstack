using TechTalk.SpecFlow;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium;

namespace SpecFlowBrowserStack
{
	[Binding]
	public class BrowserStackSpecFlowTest
	{
		private FeatureContext _featureContext;
		private ScenarioContext _scenarioContext;

		public static ThreadLocal<IWebDriver> ThreadLocalDriver = new ThreadLocal<IWebDriver>();
		private static readonly ILog log = LogManager.GetLogger(typeof(BrowserStackSpecFlowTest));

		public BrowserStackSpecFlowTest(FeatureContext featureContext, ScenarioContext scenarioContext)
		{
			_featureContext = featureContext;
			_scenarioContext = scenarioContext;
		}


		[BeforeScenario]
		public static void Initialize(ScenarioContext scenarioContext)
		{
			AppiumOptions appiumOptions = new AppiumOptions();
			appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Samsung Galaxy S20");
			appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
			appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10");
			ThreadLocalDriver.Value = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appiumOptions);
		}


		[AfterScenario]
		public static void TearDown(ScenarioContext scenarioContext)
		{
			Shutdown();
		}

		protected static void Shutdown()
		{
			if (ThreadLocalDriver.IsValueCreated)
			{
				ThreadLocalDriver.Value?.Quit();
			}
		}
	}
}
