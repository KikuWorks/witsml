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

namespace PDS.Witsml.Server.Data.Wellbores
{
    [TestClass]
    public partial class Wellbore141StoreTests : Wellbore141TestBase
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
        public void Wellbore141DataAdapter_GetFromStore_Can_Get_Wellbore()
        {
            AddParents();

            DevKit.AddAndAssert<WellboreList, Wellbore>(Wellbore);
            DevKit.GetAndAssert<WellboreList, Wellbore>(Wellbore);

       }

        [TestMethod]
        public void Wellbore141DataAdapter_AddToStore_Can_Add_Wellbore()
        {
            AddParents();

            DevKit.AddAndAssert<WellboreList, Wellbore>(Wellbore);

        }

        [TestMethod]
        public void Wellbore141DataAdapter_UpdateInStore_Can_Update_Wellbore()
        {
            AddParents();

            DevKit.AddAndAssert<WellboreList, Wellbore>(Wellbore);
            DevKit.UpdateAndAssert<WellboreList, Wellbore>(Wellbore);
            DevKit.GetAndAssert<WellboreList, Wellbore>(Wellbore);

        }

        [TestMethod]
        public void Wellbore141DataAdapter_DeleteFromStore_Can_Delete_Wellbore()
        {
            AddParents();

            DevKit.AddAndAssert<WellboreList, Wellbore>(Wellbore);
            DevKit.DeleteAndAssert<WellboreList, Wellbore>(Wellbore);
            DevKit.GetAndAssert<WellboreList, Wellbore>(Wellbore, isNotNull: false);

        }

        [TestMethod]
        public void Wellbore141WitsmlStore_GetFromStore_Can_Transform_Wellbore()
        {
            AddParents();
            DevKit.AddAndAssert<WellboreList, Wellbore>(Wellbore);

            // Re-initialize all capServer providers
            DevKit.Store.CapServerProviders = null;
            DevKit.Container.BuildUp(DevKit.Store);

            string typeIn, queryIn;
            var query = DevKit.List(DevKit.CreateQuery(Wellbore));
            DevKit.SetupParameters<WellboreList, Wellbore>(query, ObjectTypes.Wellbore, out typeIn, out queryIn);

            var options = OptionsIn.Join(OptionsIn.ReturnElements.All, OptionsIn.DataVersion.Version131);
            var request = new WMLS_GetFromStoreRequest(typeIn, queryIn, options, null);
            var response = DevKit.Store.WMLS_GetFromStore(request);

            Assert.IsFalse(string.IsNullOrWhiteSpace(response.XMLout));
            Assert.AreEqual((short)ErrorCodes.Success, response.Result);

            var result = WitsmlParser.Parse(response.XMLout);
            var version = ObjectTypes.GetVersion(result.Root);
            Assert.AreEqual(OptionsIn.DataVersion.Version131.Value, version);
        }

        [TestMethod]
        public void Wellbore141DataAdapter_AddToStore_Creates_ChangeLog()
        {
            AddParents();

            DevKit.AddAndAssert<WellboreList, Wellbore>(Wellbore);

            var result = DevKit.GetAndAssert<WellboreList, Wellbore>(Wellbore);
            var expectedHistoryCount = 1;
            var expectedChangeType = ChangeInfoType.add;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);
        }

        [TestMethod]
        public void Wellbore141DataAdapter_UpdateInStore_Updates_ChangeLog()
        {
            AddParents();

            DevKit.AddAndAssert<WellboreList, Wellbore>(Wellbore);

            // Update the Wellbore141
            Wellbore.Name = "Change";
            DevKit.UpdateAndAssert(Wellbore);

            var result = DevKit.GetAndAssert<WellboreList, Wellbore>(Wellbore);
            var expectedHistoryCount = 2;
            var expectedChangeType = ChangeInfoType.update;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);
        }

        [TestMethod]
        public void Wellbore141DataAdapter_DeleteFromStore_Updates_ChangeLog()
        {
            AddParents();

            DevKit.AddAndAssert<WellboreList, Wellbore>(Wellbore);

            // Delete the Wellbore141
            DevKit.DeleteAndAssert(Wellbore);

            var expectedHistoryCount = 2;
            var expectedChangeType = ChangeInfoType.delete;
            DevKit.AssertChangeLog(Wellbore, expectedHistoryCount, expectedChangeType);
        }

        [TestMethod]
        public void Wellbore141DataAdapter_ChangeLog_Tracks_ChangeHistory_For_Add_Update_Delete()
        {
            AddParents();

            // Add the Wellbore141
            DevKit.AddAndAssert<WellboreList, Wellbore>(Wellbore);

            // Verify ChangeLog for Add
            var result = DevKit.GetAndAssert<WellboreList, Wellbore>(Wellbore);
            var expectedHistoryCount = 1;
            var expectedChangeType = ChangeInfoType.add;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);

            // Update the Wellbore141
            Wellbore.Name = "Change";
            DevKit.UpdateAndAssert(Wellbore);

            result = DevKit.GetAndAssert<WellboreList, Wellbore>(Wellbore);
            expectedHistoryCount = 2;
            expectedChangeType = ChangeInfoType.update;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);

            // Delete the Wellbore141
            DevKit.DeleteAndAssert(Wellbore);

            expectedHistoryCount = 3;
            expectedChangeType = ChangeInfoType.delete;
            DevKit.AssertChangeLog(Wellbore, expectedHistoryCount, expectedChangeType);

            // Re-add the same Wellbore141...
            DevKit.AddAndAssert<WellboreList, Wellbore>(Wellbore);

            //... the same changeLog should be reused.
            result = DevKit.GetAndAssert<WellboreList, Wellbore>(Wellbore);
            expectedHistoryCount = 4;
            expectedChangeType = ChangeInfoType.add;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);
        }

        [TestMethod]
        public void Wellbore141DataAdapter_ChangeLog_Syncs_Wellbore_Name_Changes()
        {
            AddParents();

            // Add the Wellbore141
            DevKit.AddAndAssert<WellboreList, Wellbore>(Wellbore);

            // Assert that all Wellbore names match corresponding changeLog names
            DevKit.AssertChangeLogNames(Wellbore);

            // Update the Wellbore141 names
            Wellbore.Name = "Change";
            Wellbore.NameWell = "Well Name Change";

            DevKit.UpdateAndAssert(Wellbore);

            // Assert that all Wellbore names match corresponding changeLog names
            DevKit.AssertChangeLogNames(Wellbore);
        }

    }
}