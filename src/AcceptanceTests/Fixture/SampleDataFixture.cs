using System.Collections.Generic;
using FM.ParcelDist.Core.Domain;

namespace FM.ParcelDist.AcceptanceTests.Fixture
{
    public class SampleDataFixture
    {
        public readonly Company SampleCompany;
        public readonly Person SamplePerson;
        public readonly Organization SampleOrganization;

        public SampleDataFixture()
        {
            SampleCompany = CreateSampleCompany();
            SamplePerson = CreateSamplePerson();
            SampleOrganization = CreateSampleOrganization();
        }

        private Organization CreateSampleOrganization()
        {
            return new Organization
            {
                Departments = new List<Department>
                {
                    new InsuranceDepartment(),
                    new EmailDepartment(),
                    new RegularDepartment(),
                    new HeavyDepartment()
                }
            };
        }

        private static Person CreateSamplePerson()
        {
            return new Person
            {
                Name = "Martijn",
                Address = new Address
                {
                    Street = "Burgemeester Roosstraat",
                    HouseNumber = 33,
                    PostalCode = "3035 AC",
                    City = "Rotterdam"
                }
            };
        }

        private static Company CreateSampleCompany()
        {
            return new Company
            {
                Name = "SITA Ypenburg B.V.",
                Address = new Address
                {
                    Street = "ILSY-PLantsoen",
                    HouseNumber = 1,
                    PostalCode = "2497GA",
                    City = "Den Haag"
                },
                CcNumber = "65465424"
            };
        }
    }
}
