using System;

namespace FM.ParcelDist.Core.Domain
{
    public abstract class Department
    {
        public abstract bool Evaluate(Parcel parcel);
        protected void ShowParcelInfo(Parcel parcel)
        {
            Console.WriteLine();
            Console.WriteLine("***********************************************************");
            Console.WriteLine($"From: {parcel.Sender.Name}, To: {parcel.Recipient.Name}");
            Console.WriteLine();
        }
    }

    public class EmailDepartment : Department, IParcelProcessor
    {
        public override bool Evaluate(Parcel parcel)
        {
            return parcel.Weight <= 1;
        }

        public void Process(Parcel parcel)
        {
            ShowParcelInfo(parcel);
            Console.WriteLine($"{this.GetType().Name} Processed the parcel.");
        }
    }

    public class RegularDepartment : Department, IParcelProcessor
    {
        public override bool Evaluate(Parcel parcel)
        {
            return parcel.Weight > 1 && parcel.Weight <= 10;
        }

        public void Process(Parcel parcel)
        {
            ShowParcelInfo(parcel);
            Console.WriteLine($"{this.GetType().Name} Processed the parcel.");
        }
    }

    public class HeavyDepartment : Department, IParcelProcessor
    {
        public override bool Evaluate(Parcel parcel)
        {
            return parcel.Weight > 10;
        }

        public void Process(Parcel parcel)
        {
            ShowParcelInfo(parcel);
            Console.WriteLine($"{this.GetType().Name} Processed the parcel.");
        }
    }

    public class InsuranceDepartment : Department, IParcelSigner
    {
        public override bool Evaluate(Parcel parcel)
        {
            return parcel.Value > 1000;
        }

        public void SignOff(Parcel parcel)
        {
            ShowParcelInfo(parcel);
            Console.WriteLine($"{this.GetType().Name} Signed off the parcel.");
        }
    }

    public class SampleAddedDepartment : Department, IParcelProcessor
    {
        public override bool Evaluate(Parcel parcel)
        {
            return parcel.Weight > 50;
        }

        public void Process(Parcel parcel)
        {
            //TODO:
        }
    }
}