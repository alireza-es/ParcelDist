using System.Collections.Generic;
using System.Linq;
using FM.ParcelDist.Core.Domain;
using Xunit;

namespace FM.ParcelDist.UnitTests
{
    public class OrganizationTest
    {
        [Fact]
        public void Organization_GetSigners()
        {
            #region Prepare

            var organization = new Organization
            {
                Departments = new List<Department>
                {
                    new EmailDepartment(),
                    new HeavyDepartment(),
                    new HeavyDepartment(),
                    new InsuranceDepartment()
                }
            };

            #endregion

            #region Act

            var signersDepartments = organization.GetSignerDepartments();

            #endregion

            #region Check

            Assert.Equal(1, signersDepartments.Count);
            Assert.True(signersDepartments.ElementAt(0) is IParcelSigner);

            #endregion
        }
        [Fact]
        public void Organization_GetProcessors()
        {
            #region Prepare

            var organization = new Organization
            {
                Departments = new List<Department>
                {
                    new EmailDepartment(),
                    new HeavyDepartment(),
                    new HeavyDepartment(),
                    new InsuranceDepartment()
                }
            };

            #endregion

            #region Act

            var processorDepartments = organization.GetProcessorDepartments();

            #endregion

            #region Check

            Assert.Equal(3, processorDepartments.Count);
            Assert.True(processorDepartments.ElementAt(0) is IParcelProcessor);
            Assert.True(processorDepartments.ElementAt(1) is IParcelProcessor);
            Assert.True(processorDepartments.ElementAt(2) is IParcelProcessor);

            #endregion
        }
    }
}
