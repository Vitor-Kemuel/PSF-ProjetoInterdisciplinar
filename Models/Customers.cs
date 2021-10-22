using System.Collections.Generic;

namespace ProjectInter.Models
{
    public class Customers : Persons
    {
        public string cpf { get; set; }

        public List<Address> Address { get; set; }
    }
}