using System.Linq;
using BoDi;
using MaliosaurTest.Context;
using MaliosaurTest.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MaliosaurTest.Steps
{
    [Binding]
    public sealed class EmailsSteps:BaseStep
    {
        private MaliosaurHelper mailosaurHelper;
        public EmailsSteps(IObjectContainer objectContainer,ScenarioContext scenarioContext,EmailContext emailContext,MaliosaurHelper mailosaurHelper) : base(objectContainer,scenarioContext,emailContext)
        {
            this.mailosaurHelper = mailosaurHelper;
        }

        [Given(@"I check view of ""(.*)"" mail")]
        public void GivenICheckViewOfMail(string subject)
        {
            var emailWithDefineSubject = mailosaurHelper.TakeEmails().Single(x => x.Subject == subject);
            emailContext.SubjectEmail = subject;
            emailContext.CurrentEmail = emailWithDefineSubject;
            Assert.AreEqual(emailWithDefineSubject.Subject,subject);
        }

        [When(@"I check:")]
        public void GivenICheck(Table table)
        {
            var emailRows = table.CreateSet<EmailRow>().ToList();
            mailosaurHelper.CheckBasicInfo(emailRows);
        }


        [Then(@"I check correctness of images on mail:")]
        public void WhenICheckOfMail(Table table)
        {
            var emailImages = table.CreateSet<EmailImage>().ToList();
            mailosaurHelper.CheckImages(emailImages);
        }

        [Then(@"I check correctness of html code")]
        public void ThenICheckCorrectnessOfHtmlCode()
        {           
            mailosaurHelper.CompareHtml(emailContext.CurrentEmail.Html.Body,TestSettings.PathHtmlWelcomeTxt);
        }

    }
}
