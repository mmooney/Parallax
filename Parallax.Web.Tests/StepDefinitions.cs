using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace Parallax.Web.Tests
{
	[Binding]
    public class StepDefinitions
    {
        [Given(@"I have a valid login and password")]
        public void GivenIHaveAValidLoginAndPassword()
        {
			using(var browser = new IE("http://localhost:58577/"))
			{
			}
            //ScenarioContext.Current.Pending();
        }


        [When(@"I log in")]
        public void WhenILogIn()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see the home page")]
        public void ThenIShouldSeeTheHomePage()
        {
            ScenarioContext.Current.Pending();
        }
    }

}
