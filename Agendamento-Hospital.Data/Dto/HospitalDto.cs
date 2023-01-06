using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Dto
{
    public class HospitalDto
    {
        public int Identificado { get; set; }

        public string NomeHospital { get; set; } = null!;

        public string? CnpjHospital { get; set; }

        public string? EnderecoHospital { get; set; }

        public string? TelefoneHospital { get; set; }

        public string? CnesHospital { get; set; }

        public bool AtivoHospital { get; set; }

    }
}
