using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FM.ParcelDist.Core.Domain
{
    [XmlRoot("Container")]
    public class ParcelContainer
    {
        public int Id { get; set; }
        public DateTime ShippingDate { get; set; }
        [XmlArray("parcels")]
        public List<Parcel> Parcels { get; set; }
    }
}
