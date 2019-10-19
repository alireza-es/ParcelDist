using FM.ParcelDist.Core.Domain;
using Xunit;

namespace FM.ParcelDist.UnitTests
{
    public class ParcelTest
    {
        [Theory]
        [InlineData(10, 0)]
        [InlineData(0, 20)]
        [InlineData(10, 20)]
        [InlineData(15.9, 35.50)]
        public void CreateParcel_WithConstructor(double weight, double value)
        {
            #region Prepare

            #endregion

            #region Act

            var parcel = new Parcel(weight, value);

            #endregion

            #region Check

            Assert.Equal(weight, parcel.Weight);
            Assert.Equal(value, parcel.Value);

            #endregion
        }
    }
}
