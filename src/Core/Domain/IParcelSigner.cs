namespace FM.ParcelDist.Core.Domain
{
    public interface IParcelSigner
    {
        void SignOff(Parcel parcel);
    }
}
