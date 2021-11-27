namespace ProjectInter.Models
{
    public class ProductsPurchase
    {
        public double Quantify { get; set; }
        public double ValueTotal { get; set; }

        #region Foreign key
            public Purchase Purchase { get; set; }
            public Products Products { get; set; }
        #endregion
    }
}

