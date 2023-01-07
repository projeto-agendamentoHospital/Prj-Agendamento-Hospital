using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Dto
{
    public class BeneficiarioDto
    {
        public int IdBeneficiary { get; set; }

        public string Name { get; set; } = null!;

        public string Cpf { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string NumberCard { get; set; } = null!;

        public bool Active { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
