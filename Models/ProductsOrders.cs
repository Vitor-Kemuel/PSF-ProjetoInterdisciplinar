namespace ProjectInter.Models
{
    public class ProductsOrders
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantify { get; set; }
        public double ValueTotal => Products.TypeProduct.Price * this.Quantify;

        #region Foreign Key
            public Products Products { get; set; }
            public Order Order { get; set; }
        #endregion

    }
}
