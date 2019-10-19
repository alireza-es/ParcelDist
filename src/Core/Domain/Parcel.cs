using System.Xml.Serialization;

namespace FM.ParcelDist.Core.Domain
{
    public class Parcel
    {
        public Parcel()
        {
            
        }

        public Parcel(double weight, double value)
        {
            Weight = weight;
            Value = value + 10;
        }
        public Company Sender { get; set; }
        [XmlElement("Receipient")]
        public Person Recipient { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
    }
}
