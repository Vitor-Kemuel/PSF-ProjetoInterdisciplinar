using System.Collections.Generic;

namespace ProjectInter.Models
{
    public class Order
    {
        public int IdOrder { get; set; }
        public string CodeOrder { get; set; }
        public string Observations { get; set; }
        public int Situation { get; set; }
        public string DateToSell {get; set;}
        public string OrderRead { get; set; }
        public string OrderAccepted { get; set; }
        public string OrderDelivery { get; set; }

        #region foreign key
             public List<ProductsOrders> Itens { get; set; }
             public Employees Employees { get; set; }
             public Customers Customer { get; set; }
        #endregion
    }
}
