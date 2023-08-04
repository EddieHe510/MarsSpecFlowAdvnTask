using MarsAdvancedTask.Components.LoginPageComponents;
using MarsAdvancedTask.Drivers;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MarsAdvancedTask_SpecFlow_.Driver
{
    [TestFixture]
    public class MarsHook
    {
        public static IWebDriver marsDriver;
        protected MarsBroswer marsBroswer;


        [BeforeScenario(Order = 0)]
        public void MarsDriverStartWebsite()
        {
            MarsExtentReporting.MarsExtentReportingCreateTest(TestContext.CurrentContext.Test.MethodName);
            marsDriver = new ChromeDriver();
            marsDriver.Manage().Window.Maximize();
            marsDriver.Navigate().GoToUrl("http://localhost:5000/");

            marsBroswer = new MarsBroswer(marsDriver);
        }

        [BeforeScenario(Order = 1)]
        public void UserJsonData()
        {
            var jsonPath = File.ReadAllText(@"G:\AdvancedTask(SepcFlow)\AdvancedTask(Eddie)\MarsSpecFlowAdvnTask\MarsAdvancedTask(SpecFlow)\MarsAdvancedTask(SpecFlow)\TestData\LoginData\UserData1.json");
            var userData = JsonConvert.DeserializeObject<UserData>(jsonPath);

            ScenarioContext.Current.Set(userData, "UserData");
        }

        [AfterScenario]
        public void MarsDriverCloseBrowser()
        {
            MarsDriverEndTest();
            MarsExtentReporting.MarsExtentReportingEndReporting();
            marsDriver.Quit();
        }

        private void MarsDriverEndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    MarsExtentReporting.MarsExtentReportingLogFail($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    MarsExtentReporting.MarsExtentReportingLogInfo($"Test skipped {message}");
                    break;
                default:
                    break;
            }

            MarsExtentReporting.MarsExtentReportingLogScreenShot("Ending test", marsBroswer.MarsBroswerGetScreenShot());
        }
    }
}
