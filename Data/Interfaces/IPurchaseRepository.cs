using ProjectInter.Models;
using System;
using System.Collections.Generic;

namespace ProjectInter.Data.Interfaces
{
    public interface IPurchaseRepository
    {
        void Create(double amount, int idProduct, double inventory);

        List<Purchase> GetAllPurchases();

        Purchase GetSinglePurchase(int IdPurchase);

        string getDateTime(DateTime date);
    }
}
