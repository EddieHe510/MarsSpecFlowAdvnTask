using MarsAdvancedTask.Components.LoginPageComponents;
using MarsAdvancedTask_SpecFlow_.Components.LoginPageComponent;
using MarsAdvancedTask_SpecFlow_.Driver;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MarsAdvancedTask.FeatureStepDefinitions
{
    [Binding]
    public class MarsLoginFeatureStepDefinitions : MarsHook
    {
        private MarsLogin login;


        public MarsLoginFeatureStepDefinitions()
        {
            login = new MarsLogin();
        }

        [Given(@"I use this json data file to login the portal")]
        public void GivenIUseThisJsonDataFileToLoginThePortal()
        {
            var jsonPath = File.ReadAllText(@"G:\AdvancedTask(SepcFlow)\AdvancedTask(Eddie)\MarsSpecFlowAdvnTask\MarsAdvancedTask(SpecFlow)\MarsAdvancedTask(SpecFlow)\TestData\LoginData\UserData2.json");
            var userData = JsonConvert.DeserializeObject<UserData>(jsonPath);

            ScenarioContext.Current.Set(userData, "UserData");
        }

        [Then(@"I click the sign in button")]
        public void ThenIClickTheSignInButton()
        {
            login.clickSignInButton();
        }

        [When(@"I enter valid emailAddress and password")]
        public void WhenIEnterValidEmailAddressAndPassword()
        {
            var jsonData = ScenarioContext.Current.Get<UserData>("UserData");

            string signinEmailAddress = jsonData.emailAddress;
            string signinPassword = jsonData.password;

            login.loginWithCredentails(signinEmailAddress, signinPassword);
        }

        [Then(@"I should be able to see my account UserName in the profile page")]
        public void ThenIShouldBeAbleToSeeMyAccountUserNameInTheProfilePage()
        {
            string expecedAccountName = login.assertAccountName();
            Assert.That(expecedAccountName == "Eddie He", "Actual account name and expected account name do not match!");
        }
    }
}

