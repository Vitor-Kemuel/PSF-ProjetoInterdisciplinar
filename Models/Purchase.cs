using System;

namespace ProjectInter.Models
{
    public class Purchase
    {
        public int IdPurchase { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int Quantify { get; set; }

        public double TotalValue { get; set; }
    }
}
