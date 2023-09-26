using MarsAdvancedTask.Components.LoginPageComponents;
using MarsAdvancedTask.Components.SearchSkillsComponents;
using MarsAdvancedTask_SpecFlow_.Components.LoginPageComponent;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MarsAdvancedTask_SpecFlow_.FeatureStepDefinitions
{
    [Binding]
    public class MarsSearchSkillsFeatureStepDefinitions
    {

        private MarsLogin login;
        private MarsSearchSkills searchSkills;

        public MarsSearchSkillsFeatureStepDefinitions()
        {
            login = new MarsLogin();
            searchSkills = new MarsSearchSkills();
        }

        [Given(@"I logged into the Mars portal by using first user valid credentials")]
        public void GivenILoggedIntoTheMarsPortalByUsingFirstUserValidCredentials()
        {
            var jsonPath = File.ReadAllText(@"G:\AdvancedTask(SepcFlow)\AdvancedTask(Eddie)\MarsSpecFlowAdvnTask\MarsAdvancedTask(SpecFlow)\MarsAdvancedTask(SpecFlow)\TestData\LoginData\UserData1.json");
            var userData = JsonConvert.DeserializeObject<UserData>(jsonPath);

            ScenarioContext.Current.Set(userData, "UserData");
        }

        [Then(@"I clicked the sigin botton")]
        public void ThenIClickedTheSiginBotton()
        {
            login.clickSignInButton();
        }

        [Then(@"I insert the first user vaild email and password")]
        public void ThenIInsertTheFirstUserVaildEmailAndPassword()
        {
            var jsonData = ScenarioContext.Current.Get<UserData>("UserData");

            string signinEmailAddress = jsonData.emailAddress;
            string signinPassword = jsonData.password;

            login.loginWithCredentails(signinEmailAddress, signinPassword);
        }

        [When(@"I go to the home page by click the Mars Logo")]
        public void WhenIGoToTheHomePageByClickTheMarsLogo()
        {
            searchSkills.goToHomePage();
        }

        [When(@"I insert '([^']*)' into the search bar and select the online option")]
        public void WhenIInsertIntoTheSearchBarAndSelectTheOnlineOption(string skillName1)
        {
            searchSkills.searchByOnlineOption(skillName1);
        }


        [Then(@"I click into the first listing")]
        public void ThenIClickIntoTheFirstListing()
        {
            searchSkills.SelectTheFirstListing();
        }

        [Then(@"I should see the location type is showing online option")]
        public void ThenIShouldSeeTheLocationTypeIsShowingOnlineOption()
        {
            string locationType = searchSkills.assertLocationTypeAsOnline("This listing should be Online Location type!!");
            Assert.That(locationType == "Online", "Actual Location Type and expected Location Type do not match!");
        }


        [When(@"I insert '([^']*)' into the search bar and select the on-site option")]
        public void WhenIInsertIntoTheSearchBarAndSelectTheOn_SiteOption(string skillName2)
        {
            searchSkills.searchByOnsiteOption(skillName2);
        }

        [Then(@"I should see the location type is showing on-site option")]
        public void ThenIShouldSeeTheLocationTypeIsShowingOn_SiteOption()
        {
            string locationType = searchSkills.assertLocationTypeAsOnSite("This listing should be On-Site Location type!!");
            Assert.That(locationType == "Online", "Actual Location Type and expected Location Type do not match!");
        }


    }
}
