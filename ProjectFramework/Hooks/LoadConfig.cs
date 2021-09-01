using BoDi;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using LFL.Automation.Framework.GenericLib;
using MobileApp.ProjectLib;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
namespace MobileApp.Hooks
{
    [Binding]
    public class LoadConfig
    {
        private IObjectContainer _container;

        public LoadConfig(IObjectContainer container)
        {
            _container = container;
        }

      

        [BeforeScenario(Order = -100)]
        public void Load()
        {
            XmlConfigurator.Configure();
            var data = new RunData();

            _container.RegisterInstanceAs<IRunData>(data);
        }
    }
}
