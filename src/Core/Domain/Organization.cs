using System.Collections.Generic;
using System.Linq;

namespace FM.ParcelDist.Core.Domain
{
    public class Organization
    {
        public IList<Department> Departments { get; set; }

        public IList<Department> GetSignerDepartments()
        {
            return Departments.Where(x => x is IParcelSigner).ToList();

        }

        public IList<Department> GetProcessorDepartments()
        {
            return Departments.Where(x => x is IParcelProcessor).ToList();
        }

    }
}
