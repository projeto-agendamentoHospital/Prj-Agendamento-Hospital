using Agendamento_Hospital.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Interfaces
{
    public interface IBeneficiaryRepositorio
    {
        public List<BeneficiarioDto> GetAll();

        BeneficiarioDto ListByID(int IdBeneficiario);

        int CreateBeneficiary(BeneficiarioDto beneficiario);

        int UpdateBeneficiary(BeneficiarioDto beneficiario);

        int DeleteByID(int IdBeneficiario);
    }
}
