using MarsAdvancedTask.Drivers;
using MarsAdvancedTask_SpecFlow_.Components.LoginPageComponent;
using MarsAdvancedTask_SpecFlow_.Driver;
using MongoDB.Driver.Core.Authentication;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using System;
using System.Net.Mail;
using TechTalk.SpecFlow;

namespace MarsAdvancedTask.FeatureStepDefinitions
{
    [Binding]
    public class MarsLoginFeatureStepDefinitions : MarsHook
    {
        MarsLogin login = new MarsLogin();

        [Given(@"I click the Sign In button")]
        public void GivenIClickTheSignInButton()
        {
            login.clickSignInButton();
        }

        [Given(@"I enter valid '([^']*)', '([^']*)'")]
        public void GivenIEnterValid(string emailAddress, string password)
        {
            login.loginWithCredentails(emailAddress, password);
        }

        [Then(@"I should be able to see my account '([^']*)' in the profile page")]
        public void ThenIShouldBeAbleToSeeMyProfilePage(string userName)
        {
            string actualAccountName = login.assertAccountName();
            Assert.That(actualAccountName == userName, "Actual user name and expected user name do not match!");
        }

        [Given(@"I enter invalid '([^']*)' and vaild '([^']*)'")]
        public void GivenIEnterInvalidAndVaild(string emailAddress, string password)
        {
            login.loginWithCredentails(emailAddress, password);
        }

        [Then(@"Should be show the emailaddress error message")]
        public void ThenTheShouldBeShowTheEmailaddressErrorMessage()
        {
            string assertEmailMessage = login.emailErrorMessage();

            if (assertEmailMessage == "Please enter a valid email address")
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Assert.Fail("Actual message and expected message do not match!");
            }
        }

        [Given(@"I enter vaild '([^']*)' and invaild'([^']*)'")]
        public void GivenIEnterVaildAndInvaild(string emailAddress, string password)
        {
            login.loginWithCredentails(emailAddress, password);
        }

        [Then(@"Should be show the password error message")]
        public void ThenShouldBeShowThePasswordErrorMessage()
        {
            string assertPasswordMessage = login.passwordErrorMessage();

            if (assertPasswordMessage == "Password must be at least 6 characters")
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Assert.Fail("Actual message and expected message do not match!");
            }
        }

    }
}
