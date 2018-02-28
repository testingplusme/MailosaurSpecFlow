using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Mailosaur;
using MaliosaurTest.Context;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MaliosaurTest.Utils
{
    public class MaliosaurHelper
    {
        private EmailContext emailContext;
        public MaliosaurHelper(ScenarioContext scenarioContext)
        {
            emailContext=new EmailContext(scenarioContext);
        }

        public IEnumerable<Email> TakeEmails()
        {
            return emailContext.Mailbox.GetEmailsByRecipient(TestSettings.Email);
        }

        public void CheckBasicInfo(IEnumerable<EmailRow> emailRows)
        {
            foreach (var emailRow in emailRows)
            {
                Assert.AreEqual(emailRow.To, emailContext.CurrentEmail.To[0].Address);
                Assert.AreEqual(emailRow.From, emailContext.CurrentEmail.From[0].Address);
                Assert.AreEqual(emailRow.SenderHost, emailContext.CurrentEmail.SenderHost);
                Assert.AreEqual(emailRow.Priority, emailContext.CurrentEmail.Priority);
            }
        }

        public void CompareHtml(string htmlBody, string pathHtmlTxt)
        {
            var emailHtmlWelcomeFromServer = new HtmlDocument();
            var emailHtmlWelcomeToWordpress = new HtmlDocument();
            emailHtmlWelcomeFromServer.LoadHtml(htmlBody);
            emailHtmlWelcomeToWordpress.Load(TestSettings.PathHtmlWelcomeTxt);
            Assert.AreEqual(emailHtmlWelcomeToWordpress.DocumentNode.InnerHtml, emailHtmlWelcomeFromServer.DocumentNode.InnerHtml);
        }

        public void CheckImages(List<EmailImage> emailImages)
        {
            foreach (var defineImage in emailImages)
            {
                var emailImage = emailImages.SingleOrDefault(x => x.Alt == defineImage.Alt && x.Src == defineImage.Src);
                Assert.IsNotNull(emailImage);
            }
        }
    }
}
