using System.Linq;
using FM.ParcelDist.Core.Domain;

namespace FM.ParcelDist.Core.Services
{
    public class ParcelDistributionService
    {
        public ParcelSentResult Send(Organization organization,Parcel parcel)
        {
            var result = new ParcelSentResult();

            var signers = organization.GetSignerDepartments();

            var processors = organization.GetProcessorDepartments();


            var signerDepartment = signers.FirstOrDefault(d => d.Evaluate(parcel));
            if (signerDepartment != null)
            {
                ((IParcelSigner) signerDepartment).SignOff(parcel);

                result.ParcelDepartmentsFlow.Add(signerDepartment);
            }

            var processorDepartment = processors.FirstOrDefault(d => d.Evaluate(parcel));
            if(processorDepartment != null)
            {
                ((IParcelProcessor)processorDepartment).Process(parcel);

                result.ParcelDepartmentsFlow.Add(processorDepartment);
            }

            result.IsSent = true;

            return result;
        }
    }
}
