namespace AgendamentoHospital.DTO
{
    public class ScheduleSettingDto
    {
        /*
         IdConfiguração (primary)
        IdHospital(foreign)
        IdEspecialidade(foreign)
        IdProfissional(foreign)
        DataHoraInicioAtendimento
        DataHoraFinalAtendimento
         */
        public int IdConfig { get; set; }
        public int IdHospital { get; set; }
        public int IdSpecialty { get; set; }
        public int IdProfessional { get; set; }
        public DateTime StartDateHour { get; set; }
        public DateTime FinalDateHour { get; set; }
    }
}
