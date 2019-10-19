using System.ComponentModel;
using System.Linq;
using FM.ParcelDist.AcceptanceTests.Fixture;
using FM.ParcelDist.Core.Domain;
using Xunit;

namespace FM.ParcelDist.AcceptanceTests
{
    public class ParcelDistributionScenarios : BaseScenario
    {
        [Theory]
        [InlineData(0.8, 5)]
        [InlineData(0.8, 1000)]
        [InlineData(1, 5)]
        [Category("Email")]
        public void LowWeight_LowValue_Parcel_ShouldBeHandled_ByEmailDepartment(double weight, double value)
        {
            #region Prepare

            var parcel = new Parcel
            {
                Sender = SampleDataFixture.SampleCompany,
                Recipient = SampleDataFixture.SamplePerson,
                Weight = weight,
                Value = value
            };

            #endregion

            #region Act

            var result = Send(parcel);

            #endregion

            #region Check

            Assert.True(result.IsSent);
            Assert.NotNull(result.ParcelDepartmentsFlow);
            Assert.Single(result.ParcelDepartmentsFlow);
            Assert.IsType<EmailDepartment>(result.ParcelDepartmentsFlow.ElementAt(0));

            #endregion
        }
        [Theory]
        [InlineData(5, 5)]
        [InlineData(5, 1000)]
        [InlineData(10, 5)]
        [Category("Regular")]
        public void RegularWeight_LowValue_Parcel_ShouldBeHandled_ByRegularDepartment(double weight, double value)
        {
            #region Prepare

            var parcel = new Parcel
            {
                Sender = SampleDataFixture.SampleCompany,
                Recipient = SampleDataFixture.SamplePerson,
                Weight = weight,
                Value = value
            };

            #endregion

            #region Act

            var result = Send(parcel);

            #endregion

            #region Check

            Assert.True(result.IsSent);
            Assert.NotNull(result.ParcelDepartmentsFlow);
            Assert.Single(result.ParcelDepartmentsFlow);
            Assert.IsType<RegularDepartment>(result.ParcelDepartmentsFlow.ElementAt(0));

            #endregion
        }
        [Theory]
        [InlineData(50, 5)]
        [InlineData(50, 1000)]
        [Category("Heavy")]
        public void HeavyWeight_LowValue_Parcel_ShouldBeHandled_ByHeavyDepartment(double weight, double value)
        {
            #region Prepare

            var parcel = new Parcel
            {
                Sender = SampleDataFixture.SampleCompany,
                Recipient = SampleDataFixture.SamplePerson,
                Weight = weight,
                Value = value
            };

            #endregion

            #region Act

            var result = Send(parcel);

            #endregion

            #region Check

            Assert.True(result.IsSent);
            Assert.NotNull(result.ParcelDepartmentsFlow);
            Assert.Single(result.ParcelDepartmentsFlow);
            Assert.IsType<HeavyDepartment>(result.ParcelDepartmentsFlow.ElementAt(0));

            #endregion
        }
        [Theory]
        [InlineData(0.8, 2000)]
        [InlineData(1, 2000)]
        [Category("With SignOff")]
        public void LowWeight_HighValue_Parcel_ShouldBeHandled_ByInsuranceAndEmailDepartments(double weight, double value)
        {
            #region Prepare

            var parcel = new Parcel
            {
                Sender = SampleDataFixture.SampleCompany,
                Recipient = SampleDataFixture.SamplePerson,
                Weight = weight,
                Value = value
            };

            #endregion

            #region Act

            var result = Send(parcel);

            #endregion

            #region Check

            Assert.True(result.IsSent);
            Assert.NotNull(result.ParcelDepartmentsFlow);
            Assert.Equal(2, result.ParcelDepartmentsFlow.Count);
            Assert.IsType<InsuranceDepartment>(result.ParcelDepartmentsFlow.ElementAt(0));
            Assert.IsType<EmailDepartment>(result.ParcelDepartmentsFlow.ElementAt(1));

            #endregion
        }
        [Theory]
        [InlineData(5, 2000)]
        [InlineData(10, 2000)]
        [Category("With SignOff")]
        public void RegularWeight_HighValue_Parcel_ShouldBeHandled_ByInsuranceAndRegularDepartments(double weight, double value)
        {
            #region Prepare

            var parcel = new Parcel
            {
                Sender = SampleDataFixture.SampleCompany,
                Recipient = SampleDataFixture.SamplePerson,
                Weight = weight,
                Value = value
            };

            #endregion

            #region Act

            var result = Send(parcel);

            #endregion

            #region Check

            Assert.True(result.IsSent);
            Assert.NotNull(result.ParcelDepartmentsFlow);
            Assert.Equal(2, result.ParcelDepartmentsFlow.Count);
            Assert.IsType<InsuranceDepartment>(result.ParcelDepartmentsFlow.ElementAt(0));
            Assert.IsType<RegularDepartment>(result.ParcelDepartmentsFlow.ElementAt(1));

            #endregion
        }
        [Theory]
        [InlineData(50, 2000)]
        [Category("With SignOff")]
        public void HeavyWeight_HighValue_Parcel_ShouldBeHandled_ByInsuranceAndHeavyDepartments(double weight, double value)
        {
            #region Prepare

            var parcel = new Parcel
            {
                Sender = SampleDataFixture.SampleCompany,
                Recipient = SampleDataFixture.SamplePerson,
                Weight = weight,
                Value = value
            };

            #endregion

            #region Act

            var result = Send(parcel);

            #endregion

            #region Check

            Assert.True(result.IsSent);
            Assert.NotNull(result.ParcelDepartmentsFlow);
            Assert.Equal(2, result.ParcelDepartmentsFlow.Count);
            Assert.IsType<InsuranceDepartment>(result.ParcelDepartmentsFlow.ElementAt(0));
            Assert.IsType<HeavyDepartment>(result.ParcelDepartmentsFlow.ElementAt(1));

            #endregion
        }

    }
}
