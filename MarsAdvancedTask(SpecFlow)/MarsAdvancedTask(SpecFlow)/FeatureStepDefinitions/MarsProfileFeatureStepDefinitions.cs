using MarsAdvancedTask.Components.ProfilePageComponents;
using MarsAdvancedTask.Pages;
using MarsAdvancedTask_SpecFlow_.Components.LoginPageComponent;
using MarsAdvancedTask_SpecFlow_.Components.ProfilePageComponent;
using NUnit.Framework;
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
        MarsLogin login = new MarsLogin();
        MarsProfilePage profilePage = new MarsProfilePage();
        MarsProfileDescription profileDescription = new MarsProfileDescription();
        MarsProfileLanguages profileLanguages = new MarsProfileLanguages();

        [Then(@"I start fill up my prfile details")]
        public void ThenIStartFillUpMyPrfileDetails()
        {
            profilePage.addProfileUserDetail("User details has been added!!");
        }

        [Then(@"I can write '([^']*)' into my description text area")]
        public void ThenICanWriteIntoMyDescriptionTextArea(string description)
        {
            profileDescription.marsProfileDecriptionAdd(description);
        }

        [Then(@"I add first '([^']*)' to my language skill")]
        public void ThenIAddFirstToMyLanguageSkill(string language1)
        {
            profileLanguages.marsAddProfileLanguage1("Language1 has been added!", language1);
        }

        [Then(@"I add second '([^']*)' to my language skill")]
        public void ThenIAddSecondToMyLanguageSkill(string language2)
        {
            profileLanguages.marsAddProfileLanguage2("Language2 has been added!", language2);
        }

        [Then(@"I can edit my profile user details")]
        public void ThenICanEditMyProfileUserDetails()
        {
            profilePage.editProfileUserDetail("User details has been change!!");
        }
        [Then(@"I can edit my '([^']*)'")]
        public void ThenICanEditMy(string description)
        {
            profileDescription.marsProfileDecriptionEdit(description);
        }


    }
}