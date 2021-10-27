using System.Collections.Generic;

namespace ProjectInter.Models
{
    public class Customers : Persons
    {
        public string cpf { get; set; }

        #region Foreign Key
            public List<Address> Address { get; set; }
            public List<Order> Order { get; set; }

        #endregion
    }
}