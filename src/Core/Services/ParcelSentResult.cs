using System.Collections.Generic;
using FM.ParcelDist.Core.Domain;

namespace FM.ParcelDist.Core.Services
{
    public class ParcelSentResult
    {
        public ParcelSentResult()
        {
            ParcelDepartmentsFlow = new List<Department>();
        }
        public bool IsSent { get; set; }
        public List<Department> ParcelDepartmentsFlow { get; set; }
    }
}
