namespace ProjectInter.Models
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Complemento { get; set; }
        public string Telefone { get; set; }
    }
    public abstract class Persons
    {   
        public int IdPerson { get; set; }

        public string Name { get; set; }

        public string Cellphone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}

/*
    git add . 
    git commit -m "Git Init"
*/