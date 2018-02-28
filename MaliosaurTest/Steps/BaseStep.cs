using BoDi;
using MaliosaurTest.Context;
using TechTalk.SpecFlow;

namespace MaliosaurTest.Steps
{
    public class BaseStep
    {
        protected  IObjectContainer objectContainer;
        protected ScenarioContext scenarioContext;
        protected EmailContext emailContext;
        public BaseStep(IObjectContainer objectContainer,ScenarioContext scenarioContext,EmailContext emailContext)
        {
            this.objectContainer = objectContainer;
            this.scenarioContext = scenarioContext;
            this.emailContext = emailContext;

        }
    }
}




