using System.Collections.Generic;
using BDD.PageObjects;
using ClassLibraryFramework.Base;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public sealed class SpecDef
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        LoginPageObjects lp = new LoginPageObjects(DriverContext.Driver);

        [Given("I have entered (.*) into the (.*)")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(string username, string field)
        {
            

            if (field.ToLower() == "usernamefield")
            {
                lp.UsernameTextBox.SendKeys(username);
            }
            else
            {
                lp.PasswordTextBox.SendKeys(username);
            }

        }

        [When("I press login")]
        public void WhenIPressAdd()
        {

            // TODO: implement act (action) logic
            lp.LoginBtn.Click();
        }

        [Then("i should see the (.*) page")]
        public void ThenTheResultShouldBe(string pagename)
        {
            // TODO: implement assert (verification) logic
            if (pagename == "welcomepage")
                if (lp.IsLoginPageDisplayed() == true)
                    Assert.Fail("Login page still visible");

        }


        [Given(@"I enter the following credentials")]
        public void GivenIEnterTheFollowingCredentials(Table table)
        {
            //   var LoginCridentials = table.CreateSet<DataHolder>();
            // string lo = L

            //dynamic menu = table.CreateDynamicInstance();
            //string name = menu.Username;



            IEnumerable<dynamic> credentials = table.CreateDynamicSet();
            foreach (var users in credentials)
            {
                string v = users.Username;
                lp.UsernameTextBox.SendKeys(users.Username);
                lp.PasswordTextBox.SendKeys(users.Password);

            }
        }
        [Given(@"User enter (.*) and (.*)")]
        public void WhenUserEnterAnd(string username, string password)
        {
            lp.UsernameTextBox.SendKeys(username);
            lp.PasswordTextBox.SendKeys(password);
        }

        [Given("I reload the site")]
        public void reload()
        {
            lp.ResetToLoginScreen();
        }

    }
}
