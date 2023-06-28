﻿using MarsAdvancedTask.Drivers;
using MarsAdvancedTask_SpecFlow_.Driver;
using Newtonsoft.Json;
using OpenQA.Selenium;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarsAdvancedTask.Components.ProfilePageComponents
{
    public class MarsProfileLanguages : MarsHook
    {
        // Languages Action
        private IWebElement languagesTag => marsDriver.FindElement(By.XPath("//*[@id=>\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
        private IWebElement languagesAddNewButton => marsDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private IWebElement languageTextBox => marsDriver.FindElement(By.Name("name"));
        private IWebElement languageLevel => marsDriver.FindElement(By.Name("level"));
        private IWebElement basicOption => marsDriver.FindElement(By.XPath("//option[@value=\"Basic\"]"));
        private IWebElement fluentOption => marsDriver.FindElement(By.XPath("//option[@value=\"Fluent\"]"));
        private IWebElement conversationalOption => marsDriver.FindElement(By.XPath("//option[@value=\"Conversational\"]"));
        private IWebElement nativeOption => marsDriver.FindElement(By.XPath("//option[@value=\"Native/Bilingual\"]"));
        private IWebElement languageAddButton => marsDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        private IWebElement firstLanguagePenIcon => marsDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
        private IWebElement secondLanguagePenIcon => marsDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[3]/span[1]/i"));
        private IWebElement firstLanguageDeleteButton => marsDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
        private IWebElement secondLanguageDeleteButton => marsDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[3]/span[2]/i"));
        private IWebElement languageUpdateButton => marsDriver.FindElement(By.XPath("//input[@value=\"Update\"]"));
        private IWebElement languageMessage => marsDriver.FindElement(By.XPath("/html/body/div[1]/div"));



        public void marsProfileJumpToLanguageTag()
        {
            languagesTag.Click();
        }


        public void marsAddProfileLanguage1(string name, string language1)
        {
            MarsExtentReporting.MarsExtentReportingLogInfo(name);
            // Identify the Add New button and click on it
            MarsWait.MarsWaitToBeClickable("XPath", 5, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
            languagesAddNewButton.Click();

            // Add first language (English)
            languageTextBox.SendKeys(language1);
            languageLevel.Click();
            basicOption.Click();
            languageAddButton.Click();


        }
        public void marsAddProfileLanguage2(string name, string language2)
        {
            MarsExtentReporting.MarsExtentReportingLogInfo(name);
            // Add second language (Chinese)
            MarsWait.MarsWaitToBeClickable("XPath", 5, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
            languagesAddNewButton.Click();
            languageTextBox.SendKeys(language2);
            languageLevel.Click();
            fluentOption.Click();

            // Click the add button after fill up the form
            languageAddButton.Click();
        }

    //    public void marsProfileLanguageEdit()
    //    {
    //        // Edited first language (Japanese)
    //        firstLanguagePenIcon.Click();
    //        languageTextBox.Clear();
    //        languageTextBox.SendKeys(language3.language);
    //        languageLevel.Click();
    //        nativeOption.Click();
    //        languageUpdateButton.Click();

    //        // Edited second language
    //        MarsWait.MarsWaitToBeClickable("XPath", 5, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[3]/span[1]/i");
    //        secondLanguagePenIcon.Click();
    //        languageTextBox.Clear();
    //        languageTextBox.SendKeys(language4.language);
    //        languageLevel.Click();
    //        conversationalOption.Click();
    //        languageUpdateButton.Click();
    //    }

    //    public void marsProfileLanguageDelete()
    //    {
    //        firstLanguageDeleteButton.Click();
    //        secondLanguageDeleteButton.Click();
    //    }
    }
}


