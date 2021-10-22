namespace ProjectInter.Models
{
    public class Employees : Persons
    {
        public int IdEmployee { get; set; }

        public int FkPerson { get; set; }   

        public string Responsibility { get; set; }

        public decimal Wage { get; set; }

        #region Foreign Key
        public Persons Person { get; set; }    
        #endregion
    }
}