using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ProjectInter.Models
{
    public class Products
    {
        public int IdProducts { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public double Inventory { get; set; }
        public int Status { get; set; } // 1 - Ativo 2 - Inativo

        public List<Products> Adicionais { get; set; }

        #region Foreign Key
            public TypeProducts TypeProduct { get; set; }
            public List<ProductsOrders> Itens { get; set; }
        #endregion


    }
}
