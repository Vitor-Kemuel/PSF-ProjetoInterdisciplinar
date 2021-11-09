using System.Collections.Generic;

namespace ProjectInter.Models
{
    public class Customers : Persons
    {
        public string Cpf { get; set; }

        #region Foreign Key
            public List<Address> Address { get; set; }
        #endregion
    }
}