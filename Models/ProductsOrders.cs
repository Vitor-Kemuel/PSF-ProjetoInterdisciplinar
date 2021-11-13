namespace ProjectInter.Models
{
    public class ProductsOrders
    {
        public int Quantify { get; set; }
        public float ValueTotal { get; set; }

        #region Foreign Key
            public Products Products { get; set; }
            public Order Order { get; set; }
        #endregion

    }
}
