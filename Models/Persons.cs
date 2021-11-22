using System.ComponentModel.DataAnnotations;

namespace ProjectInter.Models
{
        public abstract class Persons
        {
            public int      IdPerson { get; set; }
            public string   Name { get; set; }
            public string   Cellphone { get; set; }
            [Required(ErrorMessage = "O campo email é obrigatório")]
            [DataType(DataType.EmailAddress)]
            public string   Email { get; set; }
            [Required(ErrorMessage = "Campo senha é obrigatório")]
            [MinLength(6, ErrorMessage = "Campo deve conter no mínimo 6 caracteres")]
            public string   Password { get; set; }
            public int      Situation {get; set; }
        }
}
