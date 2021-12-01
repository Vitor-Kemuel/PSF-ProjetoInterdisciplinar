using System;
using System.Collections.Generic;

namespace ProjectInter.Models
{
    public class Order
    {
        public int IdOrder { get; set; }
        public int Situation { get; set; }
        public DateTime DateToSell {get; set;}
        public DateTime OrderRead { get; set; }
        public DateTime OrderAccepted { get; set; }
        public DateTime OrderDelivery { get; set; }

        #region foreign key
             public List<ProductsOrders> Itens { get; set; }
             public Customers Customer { get; set; }
        #endregion
    }
}
