namespace ProjectInter.Data.Interfaces
{
    public interface IPurchaseRepository
    {
        void Create(int IdProducts);

        void GetAllPurchases();

        void GetSinglePurchase(int IdPurchase);
    }
}