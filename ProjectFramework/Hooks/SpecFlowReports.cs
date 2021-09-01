/*using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace ProjectFramework.Hooks
{
    [Binding]
    public class SpecFlowReports
    {
      public ISpecFlowOutputHelper SpecFlowOutputHelper;
      public SpecFlowReports(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            SpecFlowOutputHelper = specFlowOutputHelper;
            Console.WriteLine("I am in specflow constructor");
        }
        
        [AfterStep]
        public void TakeScreenshotAfterStep()
        {
            Console.WriteLine("I am in after step ");
            SpecFlowOutputHelper.WriteLine("Test Step Executed Successfully");
        }



    }
}
*/