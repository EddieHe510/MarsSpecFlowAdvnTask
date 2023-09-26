using MarsAdvancedTask.Components.LoginPageComponents;
using MarsAdvancedTask.Components.NotificationComponents;
using MarsAdvancedTask_SpecFlow_.Components.LoginPageComponent;
using Newtonsoft.Json;
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

        [Given(@"I use second user json file to sign in the portal")]
        public void GivenIUseSecondUserJsonFileToSignInThePortal()
        {
            var jsonPath = File.ReadAllText(@"G:\AdvancedTask(SepcFlow)\AdvancedTask(Eddie)\MarsSpecFlowAdvnTask\MarsAdvancedTask(SpecFlow)\MarsAdvancedTask(SpecFlow)\TestData\LoginData\UserData2.json");
            var userData = JsonConvert.DeserializeObject<UserData>(jsonPath);

            ScenarioContext.Current.Set(userData, "UserData");
        }

        [Then(@"I click the login button")]
        public void ThenIClickTheLoginButton()
        {
            login.clickSignInButton();
        }

        [Then(@"I insert vaild email and password")]
        public void ThenIInsertVaildEmailAndPassword()
        {
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
