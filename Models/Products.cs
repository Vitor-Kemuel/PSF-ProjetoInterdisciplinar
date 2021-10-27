using System.Collections.Generic;

namespace ProjectInter.Models
{
    public class Products
    {
        public int IdProducts { get; set; }
        public string CodeProducts { get; set; }

        public int Status { get; set; } // 1 - Ativo 2 - Inativo

        #region Foreign Key
            public List<TypeProducts> TypeProducts { get; set; }
            public List<Order> Order { get; set; }
             
        #endregion


    }
}