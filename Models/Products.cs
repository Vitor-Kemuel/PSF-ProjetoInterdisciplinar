using System.Collections.Generic;

namespace ProjectInter.Models
{
    public class Products
    {
        public int IdProducts { get; set; }
        public string CodeProducts { get; set; }
        public string Name { get; set; }
        public float Inventory { get; set; }
        public bool Status { get; set; } // 1 - Ativo 2 - Inativo

        #region Foreign Key
            public List<TypeProducts> TypeProduct { get; set; }
            public List<ProductsOrders> Itens { get; set; }
        #endregion


    }
}