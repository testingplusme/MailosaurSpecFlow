using Mailosaur;
using TechTalk.SpecFlow;

namespace MaliosaurTest.Context
{ 
    public class EmailContext
    {
        private ScenarioContext scenarioContext;
        public EmailContext(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        public string SubjectEmail
        {
            get => scenarioContext.Get<string>("SubjectEmail");
            set => scenarioContext.Set(value,"SubjectEmail");
        }

        public MailboxApi Mailbox => new MailboxApi("mailBoxId", "secretKey");

        public Email CurrentEmail
        {
            get => scenarioContext.Get<Email>("CurrentEmail");
            set => scenarioContext.Set(value, "CurrentEmail");
        }
    }
}
