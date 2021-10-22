using System;

namespace ProjectInter.Models
{
    public class Order
    {
        public int IdOrder { get; set; }  
        public string CodeOrder { get; set; }   
        public int TypeOrder { get; set; }
        // public int QuantityItens { get; set; }  quantidade deve ser por itens   
        public string Observations { get; set; }
        public string Situation { get; set; }
        // public DateTime DateToSell {get; set;}
        public string DateToSell {get; set;}
        public string OrderRead { get; set; }
        public string OrderAccepted { get; set; }
        public string OrderDelivery { get; set; }
    }
}