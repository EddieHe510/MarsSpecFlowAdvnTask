using MarsAdvancedTask.Components.LoginPageComponents;
using MarsAdvancedTask.Components.ManageListingsComponents;
using MarsAdvancedTask.Components.SearchSkillsComponents;
using MarsAdvancedTask.Components.ShareSkillComponents;
using MarsAdvancedTask_SpecFlow_.Components.LoginPageComponent;
using MarsAdvancedTask_SpecFlow_.Driver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarsAdvancedTask_SpecFlow_.FeatureStepDefinitions
{
    [Binding]
    public class MarsShareSkillFeatureDefinitions
    {
        private MarsLogin login;
        private MarsShareSkills shareSkills;
        private MarsManageListings manageListings;

        public MarsShareSkillFeatureDefinitions()
        {
            login = new MarsLogin();
            shareSkills = new MarsShareSkills();
            manageListings = new MarsManageListings();
        }

        [Given(@"I logged into the Mars portal with vaild credentials")]
        public void GivenILoggedIntoTheMarsPortalWithVaildCredentials()
        {
            login.clickSignInButton();
            var jsonData = ScenarioContext.Current.Get<UserData>("UserData");

            string signinEmailAddress = jsonData.emailAddress;
            string signinPassword = jsonData.password;

            login.loginWithCredentails(signinEmailAddress, signinPassword);
        }

        [Then(@"I should see my account name on the user profile page")]
        public void ThenIShouldSeeMyAccountNameOnTheUserProfilePage()
        {
            string expecedAccountName = login.assertAccountName();
            Assert.That(expecedAccountName == "Eddie He", "Actual account name and expected account name do not match!");
        }

        [Then(@"I click the Share skill button")]
        public void ThenIClickTheShareSkillButton()
        {
            shareSkills.ClickTheShareSkillButton("Share skills button is able to click!");
        }

        [Then(@"I complated all the column '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenIComplatedAllTheColumn(string Title, string SKDescription, string Tag1, string Tag2, string StratDate, string EndData, string StartTime, string EndTime, string SETag1, string SETag2)
        {
            shareSkills.ShareSkillAction(Title, SKDescription, Tag1, Tag2, StratDate, EndData, StartTime, EndTime, SETag1, SETag2);
        }

        [Then(@"I click the Manage Listings button and jump to that page")]
        public void ThenIClickTheManageListingsButtonAndJumpToThatPage()
        {
            manageListings.ClickManageListingsTag();
        }

        [Then(@"I delete listings name Jazz Club")]
        public void ThenIDeleteListingsNameJazzClub()
        {
            manageListings.marsDeleteListing("The listing name Jazz Club has been deleted!!");
        }
    }
}
