
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using LFL.Automation.Framework.GenericLib;
using OpenQA.Selenium;
using NUnit.Framework;
using MobileApp.Models;
using LFL.Portal.Tests.BusinessLib;
using MobileApp.ProjectLib;

namespace MobileApp.Steps
{
    [Binding]
    public sealed class CommonSteps
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IWebDriver _webDriver;
        public LFLApiCalls lflAPICalls => new LFLApiCalls(_webDriver);
        private LFLDatabaseRequestsAndUpdates lFLDatabaseRequestsAndUpdates => new LFLDatabaseRequestsAndUpdates(_webDriver);
        private readonly ScenarioContext _scenarioContext;
        private readonly IRunData _rundata;
        string accessToken;
        List<AssignRepcode> getRepcode;

        public CommonSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData)
        {
            _scenarioContext = scenarioContext;
            _webDriver = webDriver;
            _rundata = runData;
        }
               

        [Given(@"the token to access APIs is generated")]
        [When(@"the token to access APIs is generated")]
        [Then(@"the token to access APIs is generated")]
        public void GivenTheTokenToAccessApisIsGenerated()
        {
            //accessToken = (lflAPICalls.getAccessTokenAsync(_rundata.DigitalAuthToken, _rundata.ClientIdCaseflow, _rundata.ClientSecretCaseflow, _rundata.TokenContentType)).Result;
            //accessToken = (lflAPICalls.getAccessTokenAsync(_rundata.DigitalAuthToken, _rundata.ClientIdCaseflow, _rundata.ClientSecretCaseflow, _rundata.TokenContentType));
            _scenarioContext.Add("accessToken", accessToken);
            //Console.WriteLine("accessToken is ========> "+ accessToken);
            //log.Info("Access Token----------------------------------------------------------------------------------------------------------");
        }

        


    }
}
