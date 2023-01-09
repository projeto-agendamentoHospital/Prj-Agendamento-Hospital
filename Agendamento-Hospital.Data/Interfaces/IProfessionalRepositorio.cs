using Agendamento_Hospital.Data.Dto;


namespace Agendamento_Hospital.Data.Interfaces
{
    public interface IProfessionalRepositorio
    {

       
        public List<ProfessionalDto> GetAll();

        ProfessionalDto ListByID(int IdProfissional);

        int CreateProfessional(ProfessionalDto profissional);

        int UpdateProfessional(ProfessionalDto profissional);

        int DeleteByID(int IdProfissional);
    }
}
