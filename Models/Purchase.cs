using System;

namespace ProjectInter.Models
{
    public class Purchase
    {
        public int IdPurchase { get; set; }
        public DateTime PurchaseDate { get; set; }

        #region Foreign Key
            public ProductsPurchase itens { get; set; }
        #endregion
    }
}
