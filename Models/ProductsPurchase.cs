namespace ProjectInter.Models
{
    public class ProductsPurchase
    {
        public int Quantify { get; set; }
        public float ValueTotal { get; set; }

        #region Foreign key
            public Purchase Purchase { get; set; }
            public Products Products { get; set; }
        #endregion
    }
}

