namespace FM.ParcelDist.Core.Domain
{
    public abstract class Contact
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class Company : Contact
    {
        public string CcNumber { get; set; }
    }

    public class Person : Contact
    {

    }
}