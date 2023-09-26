using MarsAdvancedTask.Components.ProfilePageComponents;
using MarsAdvancedTask.Drivers;
using MarsAdvancedTask_SpecFlow_.Components.ProfilePageComponent;
using MarsAdvancedTask_SpecFlow_.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarsAdvancedTask.Pages
{
    public class MarsProfilePage : MarsHook
    {
        MarsProfileUserDetails userDetails = new MarsProfileUserDetails();
        MarsProfileDescription description = new MarsProfileDescription();

        private IWebElement userDropDownList => marsDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
        private IWebElement goToProfileOption => marsDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span/div/a[1]"));
        private IWebElement shareSkillButton => marsDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a"));
        public void goToProfilePage()
        {
            userDropDownList.Click();
            goToProfileOption.Click();
        }

        public void createNewListing(string name)
        {
            MarsExtentReporting.MarsExtentReportingLogInfo(name);
            shareSkillButton.Click();
            //shareSkills.ShareSkillAction();
        }

        public void addProfileUserDetail(string name)
        {
            MarsExtentReporting.MarsExtentReportingLogInfo(name);
            userDetails.addUserDetails();
        }

        public void editProfileUserDetail(string name)
        {
            MarsExtentReporting.MarsExtentReportingLogInfo(name);
            userDetails.editUserDetails();
        }

        public void notificationMarkAsRead(string name)
        {
            //notification.markFirstNotificationAsRead();
        }
    }
}
