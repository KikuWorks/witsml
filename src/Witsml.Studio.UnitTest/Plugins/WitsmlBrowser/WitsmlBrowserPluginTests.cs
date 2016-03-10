﻿using Energistics.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDS.Witsml.Studio.Plugins.WitsmlBrowser.ViewModels;
using PDS.Witsml.Studio.Plugins.WitsmlBrowser.ViewModels.Request;
using PDS.Witsml.Studio.Runtime;

namespace PDS.Witsml.Studio.Plugins.WitsmlBrowser
{
    [TestClass]
    public class WitsmlBrowserPluginTests
    {
        private BootstrapperHarness _bootstrapper;
        private TestRuntimeService _runtime;
        private MainViewModel _mainViewModel;

        [TestInitialize]
        public void TestSetup()
        {
            _bootstrapper = new BootstrapperHarness();
            _runtime = new TestRuntimeService(_bootstrapper.Container);
            _mainViewModel = new MainViewModel(_runtime);
        }

        [TestMethod]
        public void Can_load_mainViewModel_screens()
        {
            _mainViewModel.LoadScreens();
            
            Assert.AreEqual(2, _mainViewModel.Items.Count);
        }

        [TestMethod]
        public void Can_get_witsml_version_enum()
        {
            // Test version 131
            Assert.AreEqual(WMLSVersion.WITSML131, _mainViewModel.GetWitsmlVersionEnum(OptionsIn.DataVersion.Version131.Value));

            // Test version 141
            Assert.AreEqual(WMLSVersion.WITSML141, _mainViewModel.GetWitsmlVersionEnum(OptionsIn.DataVersion.Version141.Value));

            // Test null version
            Assert.AreEqual(WMLSVersion.WITSML141, _mainViewModel.GetWitsmlVersionEnum(null));
        }

        [TestMethod]
        public void Can_create_proxy()
        {
            Assert.IsNotNull(_mainViewModel.CreateProxy());
        }

        [TestMethod]
        public void Can_load_requestViewModel_screens()
        {
            var mainViewModel = new MainViewModel(_runtime);
            var requestViewModel = new RequestViewModel(_runtime);

            mainViewModel.Items.Add(requestViewModel);
            requestViewModel.LoadScreens();

            Assert.AreEqual(2, requestViewModel.Items.Count);
        }
    }
}