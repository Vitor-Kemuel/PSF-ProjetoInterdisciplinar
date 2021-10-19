namespace ProjectInter.Models
{
    public class Customers : Persons
    {
        public int IdCustomers { get; set; }

        public int FkPerson { get; set; }  

        public string cpf { get; set; }
    }
}