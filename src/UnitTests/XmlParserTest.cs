using FM.ParcelDist.Core.Domain;
using FM.ParcelDist.Core.Utility;
using Xunit;

namespace FM.ParcelDist.UnitTests
{
    public class XmlParserTest
    {
        [Theory]
        [InlineData("Files/Container.xml")]
        public void LoadXml_To_ParcelContainer(string xmlFilePath)
        {
            #region Prepare

            #endregion

            #region Act

            var container = XmlParser.LoadXml<ParcelContainer>(xmlFilePath);

            #endregion

            #region Check

            Assert.NotNull(container);
            Assert.Equal(4, container.Parcels.Count);
            Assert.Equal(68465468, container.Id);

            #endregion
        }
    }
}
