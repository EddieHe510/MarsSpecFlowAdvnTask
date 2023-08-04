using MarsAdvancedTask.Components.LoginPageComponents;
using MarsAdvancedTask.Components.NotificationComponents;
using MarsAdvancedTask_SpecFlow_.Components.LoginPageComponent;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace MarsAdvancedTask_SpecFlow_.FeatureStepDefinitions
{
    [Binding]
    public class MarsNotificationFeatureStepDefinitions
    {
        private MarsLogin login;
        private MarsNotification notification;

        public MarsNotificationFeatureStepDefinitions()
        {
            login = new MarsLogin();
            notification = new MarsNotification();
        }


        [Given(@"I logged into the Mars portal using valid credentials")]
        public void GivenILoggedIntoTheMarsPortalUsingValidCredentials()
        {
            login.clickSignInButton();
            var jsonData = ScenarioContext.Current.Get<UserData>("UserData");

            string signinEmailAddress = jsonData.emailAddress;
            string signinPassword = jsonData.password;

            login.loginWithCredentails(signinEmailAddress, signinPassword);
        }

        [When(@"I click the notification dropdown list and select the see all option")]
        public void WhenIClickTheNotificationDropdownListAndSelectTheSeeAllOption()
        {
            notification.goToNotificationPage();
        }

        [Then(@"I should see all my notification and mark first notification as read")]
        public void ThenIShouldSeeAllMyNotificationAndMarkFirstNotificationAsRead()
        {
            notification.markFirstNotificationAsRead("Mark the first notification!");
        }

        [Then(@"I should see the successfull message pop-up to the portal")]
        public void ThenIShouldSeeTheSuccessfullMessagePop_UpToThePortal()
        {
            string successfulMessage = notification.assertTheSuccessfulMessage("The first notification has been marked!");
            Assert.That(successfulMessage == "Notification updated", "Actual message and expected message do not match!");
        }
    }
}
