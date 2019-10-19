using FM.ParcelDist.Core.Domain;
using FM.ParcelDist.Core.Services;

namespace FM.ParcelDist.AcceptanceTests.Fixture
{
    public abstract class BaseScenario
    {
        protected SampleDataFixture SampleDataFixture { get; set; }

        protected BaseScenario()
        {
            SampleDataFixture = new SampleDataFixture();
        }

        protected ParcelSentResult Send(Parcel parcel)
        {
            var distributionService = new ParcelDistributionService();

            return distributionService.Send(SampleDataFixture.SampleOrganization, parcel);
        }

    }
}