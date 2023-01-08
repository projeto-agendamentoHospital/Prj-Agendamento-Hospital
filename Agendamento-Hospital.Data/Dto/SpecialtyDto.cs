using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Dto
{
    public class SpecialtyDto
    {
        public int IdSpecialty { get; set; }

        public string NomeSpecialy { get; set; }

        public string? DescricaoSpecialy { get; set; }

        public  bool AtivoSpecialy { get; set; }
    }
}
