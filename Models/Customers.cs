namespace ProjectInter.Models
{
    public class Customers : Persons
    {
        public string Cpf { get; set; }

        #region Foreign Key
            public Address Address { get; set; } = new Address();
        #endregion
    }
}
