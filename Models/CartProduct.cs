using System.Collections.Generic;

namespace ProjectInter.Models
{
    public class CartProduct
    {
        public int IdPrimary { get; set; }
        public List<int> IdAdd { get; set; }
        public int Amount { get; set; }
    }
}
