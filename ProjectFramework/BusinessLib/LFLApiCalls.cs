//using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Text;
using IdentityModel.Client;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using NUnit.Framework;
using static System.Net.HttpStatusCode;
using TechTalk.SpecFlow;
using System.Net;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using MobileApp.Models;
using LFL.Automation.Framework.GenericLib;
using System.Threading;
using System.Net.Http;
using Polly;
using System.Reflection;

namespace MobileApp.Steps
{
    public class LFLApiCalls
    {
        //private readonly CallbackRequest _callback = new CallbackRequest();
        public IWebDriver driver;

        public LFLApiCalls(IWebDriver cdriver)
        {
            this.driver = cdriver;
        }

        //public async Task<string> getAccessTokenAsync(string endpoint, string client_id, string client_secret, string content_type)
        //{
        //    System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        //    HttpClient client = new HttpClient();
        //    var authenticationCredentials = new Dictionary<string, string>
        //            {
        //                { "grant_type", "client_credentials"},
        //                { "client_id",client_id },
        //                { "client_secret",client_secret},
        //                { "scope","scope.caseflowapi"}
        //            };

        //    FormUrlEncodedContent content = new FormUrlEncodedContent(authenticationCredentials);
        //    Thread.Sleep(2000);
        //    HttpResponseMessage response = await client.PostAsync(endpoint, content);
        //    Thread.Sleep(2000);


        //    if (response.StatusCode != System.Net.HttpStatusCode.OK)
        //    {
        //        string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
        //        throw new ApplicationException(message);
        //    }
        //    var jsonContent = await response.Content.ReadAsStringAsync();
        //    // Console.WriteLine("<=== response is =======> " + jsonContent.ToString());
        //    //Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
        //    //return tok.AccessToken;
        //}
    }
}
