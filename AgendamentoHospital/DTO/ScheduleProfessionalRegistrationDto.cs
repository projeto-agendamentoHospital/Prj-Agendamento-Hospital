using System.ComponentModel.DataAnnotations;

namespace AgendamentoHospital.DTO
{
    public class ScheduleProfessionalRegistrationDto
    {
        public int IdProfessional { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        public string Name { get; set; }

        //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor insira um número válido!")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
      
    }
}
