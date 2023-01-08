using Agendamento_Hospital.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Interfaces
{

    public interface IHospitalRespositorio
    {
        public List<Dto.HospitalDto> ListarTodas();

        public HospitalDto ListarPorId(int IdHospital);

        int CadastrarHospital(HospitalDto cadastrarHospital);

        int AtualizarHospital(HospitalDto AtualizaHospital);

        int ExcluirHospital(int IdHospital);

    }
}
