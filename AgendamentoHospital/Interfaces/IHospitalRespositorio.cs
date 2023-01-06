using Agendamento_Hospital.Data.Dto;

namespace AgendamentoHospital.Interfaces
{
    public interface IHospitalRespositorio
    {
        public List<HospitalDto> hospitalDtos();

        HospitalDto ListarHospitalPorId(int IdHospital);

        int Cadastrar(HospitalDto cadastrarHospital);

        int Atualizar(HospitalDto AtualizaHospital);

        int Excluir(int IdHospital);

    }
}
