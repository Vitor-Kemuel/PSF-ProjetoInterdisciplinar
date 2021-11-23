using ProjectInter.Models;
using System.Collections.Generic;

namespace ProjectInter.Data.Interfaces
{
    public interface IPurchaseRepository
    {
        void Create(Purchase purchase);

        List<Purchase> GetAllPurchases();

        Purchase GetSinglePurchase(int IdPurchase);
    }
}
