﻿using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using MarsAdvancedTask.Drivers;

namespace MarsAdvancedTask_SpecFlow_.Driver
{
    [TestFixture]
    public class MarsHook
    {
        public static IWebDriver marsDriver;
        protected MarsBroswer marsBroswer;


        [BeforeScenario]
        public void MarsDriverStartWebsite()
        {
            MarsExtentReporting.MarsExtentReportingCreateTest(TestContext.CurrentContext.Test.MethodName);
            marsDriver = new ChromeDriver();
            marsDriver.Manage().Window.Maximize();
            marsDriver.Navigate().GoToUrl("http://localhost:5000/");

            marsBroswer = new MarsBroswer(marsDriver);
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