using System.Collections.Generic;
using System.Linq;
using FM.ParcelDist.AcceptanceTests.Fixture;
using FM.ParcelDist.Core.Domain;
using FM.ParcelDist.Core.Services;
using FM.ParcelDist.Core.Utility;
using Xunit;

namespace FM.ParcelDist.AcceptanceTests
{
    public class XmlFileDistributionScenarios : BaseScenario
    {
        const string XmlFilePath = "Files/Container.xml";

        [Fact]
        public void LoadXmlFile_Process_Parcels_Correctly()
        {
            #region Prepare

            var container = XmlParser.LoadXml<ParcelContainer>(XmlFilePath);

            var service = new ParcelDistributionService();

            var sentResults = new List<ParcelSentResult>();

            #endregion

            #region Act 

            foreach (var parcel in container.Parcels)
            {
                var result = service.Send(SampleDataFixture.SampleOrganization, parcel);

                Assert.True(result.IsSent);

                sentResults.Add(result);
            }

            #endregion

            #region Check

            Assert.Equal(container.Parcels.Count, sentResults.Count);

            #region Parcel #1 - Weight: 0.02, Value: 0.0

            var currentResult = sentResults.ElementAt(0);

            Assert.True(currentResult.IsSent);
            Assert.NotNull(currentResult.ParcelDepartmentsFlow);
            Assert.Single(currentResult.ParcelDepartmentsFlow);
            Assert.IsType<EmailDepartment>(currentResult.ParcelDepartmentsFlow.ElementAt(0));


            #endregion

            #region Parcel #2 - Weight: 2.0, Value: 0.0

            currentResult = sentResults.ElementAt(1);

            Assert.True(currentResult.IsSent);
            Assert.NotNull(currentResult.ParcelDepartmentsFlow);
            Assert.Single(currentResult.ParcelDepartmentsFlow);
            Assert.IsType<RegularDepartment>(currentResult.ParcelDepartmentsFlow.ElementAt(0));


            #endregion

            #region Parcel #3 - Weight: 100.0, Value: 2000.0

            currentResult = sentResults.ElementAt(2);

            Assert.True(currentResult.IsSent);
            Assert.NotNull(currentResult.ParcelDepartmentsFlow);
            Assert.Equal(2, currentResult.ParcelDepartmentsFlow.Count);
            Assert.IsType<InsuranceDepartment>(currentResult.ParcelDepartmentsFlow.ElementAt(0));
            Assert.IsType<HeavyDepartment>(currentResult.ParcelDepartmentsFlow.ElementAt(1));


            #endregion

            #region Parcel #4 - Weight: 11, Value: 500

            currentResult = sentResults.ElementAt(3);

            Assert.True(currentResult.IsSent);
            Assert.NotNull(currentResult.ParcelDepartmentsFlow);
            Assert.Single(currentResult.ParcelDepartmentsFlow);
            Assert.IsType<HeavyDepartment>(currentResult.ParcelDepartmentsFlow.ElementAt(0));


            #endregion

            #endregion

        }
    }
}
