using System;
using System.Collections.Generic;
using System.Threading;
using FM.ParcelDist.Core.Domain;
using FM.ParcelDist.Core.Services;
using FM.ParcelDist.Core.Utility;

namespace FM.ParcelDist.ConsoleApp
{
    class Program
    {
        const string XmlFilePath = "Files/Container.xml";
        static void Main(string[] args)
        {
            var container = XmlParser.LoadXml<ParcelContainer>(XmlFilePath);
            var defaultOrganization = CreateOrganization();

            Console.WriteLine("***********************************************************");
            Console.WriteLine($"************** {container.Parcels.Count} Parcels is ready to process **************");
            Console.WriteLine("***********************************************************");
            Console.WriteLine();
            Console.WriteLine();

            Process(defaultOrganization, container);

            Console.WriteLine();
            Console.WriteLine("*************************     Done!    *************************");
            Console.WriteLine();

        }

        private static void Process(Organization organization, ParcelContainer container)
        {
            var service = new ParcelDistributionService();

            foreach (var parcel in container.Parcels)
            {
                service.Send(organization, parcel);

                Thread.Sleep(3000);//Just for simulation
            }
        }
        private static Organization CreateOrganization()
        {
            return new Organization
            {
                Departments = new List<Department>
                {
                    new InsuranceDepartment(),
                    new EmailDepartment(),
                    new RegularDepartment(),
                    new HeavyDepartment(),
                    new SampleAddedDepartment()
                }
            };
        }
    }
}
