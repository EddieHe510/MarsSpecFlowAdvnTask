using MarsAdvancedTask.Components.LoginPageComponents;
using MarsAdvancedTask.Components.ProfilePageComponents;
using MarsAdvancedTask.Pages;
using MarsAdvancedTask_SpecFlow_.Components.LoginPageComponent;
using MarsAdvancedTask_SpecFlow_.Components.ProfilePageComponent;
using Newtonsoft.Json;
using NUnit.Framework;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarsAdvancedTask.FeatureStepDefinitions
{
    [Binding]
    public class MarsProfileFeatureStepDefinitions
    {
        private MarsLogin login;
        private MarsProfilePage profilePage;
        private MarsProfileUserDetails userDetails;
        private MarsProfileDescription profileDescription;
        private MarsProfileLanguages profileLanguages;

        public MarsProfileFeatureStepDefinitions()
        {
            login = new MarsLogin();
            profilePage = new MarsProfilePage();
            profileDescription = new MarsProfileDescription();
            profileLanguages = new MarsProfileLanguages();
            userDetails = new MarsProfileUserDetails();
        }

        [Given(@"I use the first user json data to sigin in the Mars portal")]
        public void GivenIUseTheFirstUserJsonDataToSiginInTheMarsPortal()
        {
            var jsonPath = File.ReadAllText(@"G:\AdvancedTask(SepcFlow)\AdvancedTask(Eddie)\MarsSpecFlowAdvnTask\MarsAdvancedTask(SpecFlow)\MarsAdvancedTask(SpecFlow)\TestData\LoginData\UserData2.json");
            var userData = JsonConvert.DeserializeObject<UserData>(jsonPath);

            ScenarioContext.Current.Set(userData, "UserData");
        }

        [Then(@"I click the sigin button")]
        public void ThenIClickTheSiginButton()
        {
            login.clickSignInButton();
        }

        [Then(@"I insert the first user email address and password")]
        public void ThenIInsertTheFirstUserEmailAddressAndPassword()
        {
            var jsonData = ScenarioContext.Current.Get<UserData>("UserData");

            string signinEmailAddress = jsonData.emailAddress;
            string signinPassword = jsonData.password;

            login.loginWithCredentails(signinEmailAddress, signinPassword);
        }

        [When(@"I see my account name on the user profile page")]
        public void WhenISeeMyAccountNameOnTheUserProfilePage()
        {
            string expecedAccountName = login.assertAccountName();
            Assert.That(expecedAccountName == "Eddie He", "Actual account name and expected account name do not match!");
        }

        [When(@"I add my user details")]
        public void WhenIAddMyUserDetails()
        {
            profilePage.addProfileUserDetail("User details has been added!!");
        }

        [Then(@"I should see the add successfull message")]
        public void ThenIShouldSeeTheAddSuccessfullMessage()
        {
            string updateSuccessfullyMessage = userDetails.assertSuccessAddMessage();
            Assert.That(updateSuccessfullyMessage == "Availability updated", "Actual message and expected message do not match!");
        }

        [Then(@"I am add my first language including '([^']*)' name and language level")]
        public void ThenIAmAddMyFirstLanguageIncludingNameAndLanguageLevel(string language1)
        {
            profileLanguages.marsAddProfileLanguage1("Language1 has been added!", language1);
        }

        [Then(@"Then I am add my second language including '([^']*)' name and language level")]
        public void ThenThenIAmAddMySecondLanguageIncludingNameAndLanguageLevel(string language2)
        {
            profileLanguages.marsAddProfileLanguage2("Language2 has been added!", language2);
        }

        [Then(@"I am add my '([^']*)' into the description text area")]
        public void ThenIAmAddMyIntoTheDescriptionTextArea(string description)
        {
            profileDescription.marsProfileDecriptionEdit(description);
        }


        [Then(@"I can edit my profile user details")]
        public void ThenICanEditMyProfileUserDetails()
        {
            profilePage.editProfileUserDetail("User details has been edit!!");
        }

        [Then(@"I should see the edit successfull message")]
        public void ThenIShouldSeeTheEditSuccessfullMessage()
        {
            string updateSuccessfullyMessage = userDetails.assertSuccessEditMessage();
            Assert.That(updateSuccessfullyMessage == "Availability updated", "Actual message and expected message do not match!");
        }

        [Then(@"I am edit my first language including '([^']*)' name and language level")]
        public void ThenIAmEditMyFirstLanguageIncludingNameAndLanguageLevel(string language3)
        {
            profileLanguages.marsEditProfileLanguage1("Language1 has been changed!!", language3);
        }

        [Then(@"I am edit my second language including '([^']*)' name and language level")]
        public void ThenIAmEditMySecondLanguageIncludingNameAndLanguageLevel(string language4)
        {
            profileLanguages.marsEditProfileLanguage2("Language2 has been changed!!", language4);
        }

        [Then(@"I edit my '([^']*)' into the description text area")]
        public void ThenIEditMyIntoTheDescriptionTextArea(string description)
        {
            profileDescription.marsProfileDecriptionEdit(description);
        }


    }
}