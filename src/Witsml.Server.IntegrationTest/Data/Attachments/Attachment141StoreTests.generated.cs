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

namespace PDS.Witsml.Server.Data.Attachments
{
    [TestClass]
    public partial class Attachment141StoreTests : Attachment141TestBase
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
        public void Attachment141DataAdapter_GetFromStore_Can_Get_Attachment()
        {
            AddParents();

            DevKit.AddAndAssert<AttachmentList, Attachment>(Attachment);
            DevKit.GetAndAssert<AttachmentList, Attachment>(Attachment);

       }

        [TestMethod]
        public void Attachment141DataAdapter_AddToStore_Can_Add_Attachment()
        {
            AddParents();

            DevKit.AddAndAssert<AttachmentList, Attachment>(Attachment);

        }

        [TestMethod]
        public void Attachment141DataAdapter_UpdateInStore_Can_Update_Attachment()
        {
            AddParents();

            DevKit.AddAndAssert<AttachmentList, Attachment>(Attachment);
            DevKit.UpdateAndAssert<AttachmentList, Attachment>(Attachment);
            DevKit.GetAndAssert<AttachmentList, Attachment>(Attachment);

        }

        [TestMethod]
        public void Attachment141DataAdapter_DeleteFromStore_Can_Delete_Attachment()
        {
            AddParents();

            DevKit.AddAndAssert<AttachmentList, Attachment>(Attachment);
            DevKit.DeleteAndAssert<AttachmentList, Attachment>(Attachment);
            DevKit.GetAndAssert<AttachmentList, Attachment>(Attachment, isNotNull: false);

        }

        [TestMethod]
        public void Attachment141DataAdapter_AddToStore_Creates_ChangeLog()
        {
            AddParents();

            DevKit.AddAndAssert<AttachmentList, Attachment>(Attachment);

            var result = DevKit.GetAndAssert<AttachmentList, Attachment>(Attachment);
            var expectedHistoryCount = 1;
            var expectedChangeType = ChangeInfoType.add;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);
        }

        [TestMethod]
        public void Attachment141DataAdapter_UpdateInStore_Updates_ChangeLog()
        {
            AddParents();

            DevKit.AddAndAssert<AttachmentList, Attachment>(Attachment);

            // Update the Attachment141
            Attachment.Name = "Change";
            DevKit.UpdateAndAssert(Attachment);

            var result = DevKit.GetAndAssert<AttachmentList, Attachment>(Attachment);
            var expectedHistoryCount = 2;
            var expectedChangeType = ChangeInfoType.update;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);
        }

        [TestMethod]
        public void Attachment141DataAdapter_DeleteFromStore_Updates_ChangeLog()
        {
            AddParents();

            DevKit.AddAndAssert<AttachmentList, Attachment>(Attachment);

            // Delete the Attachment141
            DevKit.DeleteAndAssert(Attachment);

            var expectedHistoryCount = 2;
            var expectedChangeType = ChangeInfoType.delete;
            DevKit.AssertChangeLog(Attachment, expectedHistoryCount, expectedChangeType);
        }

        [TestMethod]
        public void Attachment141DataAdapter_ChangeLog_Tracks_ChangeHistory_For_Add_Update_Delete()
        {
            AddParents();

            // Add the Attachment141
            DevKit.AddAndAssert<AttachmentList, Attachment>(Attachment);

            // Verify ChangeLog for Add
            var result = DevKit.GetAndAssert<AttachmentList, Attachment>(Attachment);
            var expectedHistoryCount = 1;
            var expectedChangeType = ChangeInfoType.add;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);

            // Update the Attachment141
            Attachment.Name = "Change";
            DevKit.UpdateAndAssert(Attachment);

            result = DevKit.GetAndAssert<AttachmentList, Attachment>(Attachment);
            expectedHistoryCount = 2;
            expectedChangeType = ChangeInfoType.update;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);

            // Delete the Attachment141
            DevKit.DeleteAndAssert(Attachment);

            expectedHistoryCount = 3;
            expectedChangeType = ChangeInfoType.delete;
            DevKit.AssertChangeLog(Attachment, expectedHistoryCount, expectedChangeType);

            // Re-add the same Attachment141...
            DevKit.AddAndAssert<AttachmentList, Attachment>(Attachment);

            //... the same changeLog should be reused.
            result = DevKit.GetAndAssert<AttachmentList, Attachment>(Attachment);
            expectedHistoryCount = 4;
            expectedChangeType = ChangeInfoType.add;
            DevKit.AssertChangeLog(result, expectedHistoryCount, expectedChangeType);
        }

        [TestMethod]
        public void Attachment141DataAdapter_ChangeLog_Syncs_Attachment_Name_Changes()
        {
            AddParents();

            // Add the Attachment141
            DevKit.AddAndAssert<AttachmentList, Attachment>(Attachment);

            // Assert that all Attachment names match corresponding changeLog names
            DevKit.AssertChangeLogNames(Attachment);

            // Update the Attachment141 names
            Attachment.Name = "Change";
            Attachment.NameWell = "Well Name Change";

            Attachment.NameWellbore = "Wellbore Name Change";

            DevKit.UpdateAndAssert(Attachment);

            // Assert that all Attachment names match corresponding changeLog names
            DevKit.AssertChangeLogNames(Attachment);
        }

    }
}