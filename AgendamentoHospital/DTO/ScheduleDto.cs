namespace AgendamentoHospital.DTO
{
    public class ScheduleDto
    {
        public int IdSchedule { get; set; }
        public int IdHospital { get; set; }
        public int IdSpecialty { get; set; }
        public int IdProfessional { get; set; }
        public DateTime DateHourSchedule { get; set; }
        public int IdBeneficiary { get; set; }
        public bool IsActiveSchedule { get; set; }
    }
}
