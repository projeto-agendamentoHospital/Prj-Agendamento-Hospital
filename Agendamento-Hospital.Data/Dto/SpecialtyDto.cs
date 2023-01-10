using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Dto
{
    public class SpecialtyDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSpecialty { get; set; }

        public string NomeSpecialy { get; set; }

        public string? DescricaoSpecialy { get; set; }

        public  bool AtivoSpecialy { get; set; }
    }
}
