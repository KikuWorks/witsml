//----------------------------------------------------------------------- 
// PDS.Witsml.Server, 2016.1
//
// Copyright 2016 Petrotechnical Data Systems
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

// ----------------------------------------------------------------------
// <auto-generated>
//     Changes to this file may cause incorrect behavior and will be lost
//     if the code is regenerated.
// </auto-generated>
// ----------------------------------------------------------------------

using Energistics.DataAccess;
using Energistics.DataAccess.WITSML141;
using Energistics.DataAccess.WITSML141.ComponentSchemas;
using Energistics.DataAccess.WITSML141.ReferenceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PDS.Witsml.Server.Data.Logs
{
    [TestClass]
    public partial class Log141StoreTests : Log141TestBase
    {
        partial void BeforeEachTest();

        partial void AfterEachTest();

        protected override void OnTestSetUp()
        {
            BeforeEachTest();
        }

        protected override void OnTestCleanUp()
        {
            AfterEachTest();
        }

        [TestMethod]
        public void Log141DataAdapter_GetFromStore_Can_Get_Log()
        {
            AddParents();
            DevKit.AddAndAssert<LogList, Log>(Log);
            DevKit.GetAndAssert<LogList, Log>(Log);
       }

        [TestMethod]
        public void Log141DataAdapter_AddToStore_Can_Add_Log()
        {
            AddParents();
            DevKit.AddAndAssert<LogList, Log>(Log);
        }

        [TestMethod]
        public void Log141DataAdapter_UpdateInStore_Can_Update_Log()
        {
            AddParents();
            DevKit.AddAndAssert<LogList, Log>(Log);
            DevKit.UpdateAndAssert<LogList, Log>(Log);
            DevKit.GetAndAssert<LogList, Log>(Log);
        }

        [TestMethod]
        public void Log141DataAdapter_DeleteFromStore_Can_Delete_Log()
        {
            AddParents();
            DevKit.AddAndAssert<LogList, Log>(Log);
            DevKit.DeleteAndAssert<LogList, Log>(Log);
            DevKit.GetAndAssert<LogList, Log>(Log, isNotNull: false);
        }

        [TestMethod]
        public void Log141WitsmlStore_GetFromStore_Can_Transform_Log()
        {
            AddParents();

            DevKit.AddAndAssert<LogList, Log>(Log);

            string typeIn, queryIn;
            var query = DevKit.List(DevKit.CreateQuery(Log));
            DevKit.SetupParameters<LogList, Log>(query, ObjectTypes.Log, out typeIn, out queryIn);

            var options = OptionsIn.Join(OptionsIn.ReturnElements.All, OptionsIn.DataVersion.Version131, OptionsIn.MaxReturnNodes.Eq(10));
            var request = new WMLS_GetFromStoreRequest(typeIn, queryIn, options, null);
            var response = DevKit.Store.WMLS_GetFromStore(request);

            Assert.IsFalse(string.IsNullOrWhiteSpace(response.XMLout));
            Assert.AreEqual((short)ErrorCodes.Success, response.Result);

            var result = WitsmlParser.Parse(response.XMLout);
            var version = ObjectTypes.GetVersion(result.Root);
            Assert.AreEqual(OptionsIn.DataVersion.Version131.Value, version);
        }
    }
}