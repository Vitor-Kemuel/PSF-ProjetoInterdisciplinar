namespace ProjectInter.Models
{
    public class Employee : Persons
    {
        public int IdEmployee { get; set; }

        public int FkPerson { get; set; }   

        public string Responsibility { get; set; }

        public decimal Wage { get; set; }
    }
}