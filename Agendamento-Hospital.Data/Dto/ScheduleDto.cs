using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Dto
{
    public class ScheduleDto
    {
        public int IdSchedule { get; set; }

        public int IdHospitalSchedule { get; set; }
        
        public int IdSpecialtySchedule { get; set; }
        
        public int IdProfissionalSchedule { get; set; }
        
        public DateTime? DataHoraSchedule { get; set; }

        public int IdBeneficiarySchedule { get; set; }

        public bool AtivoSchedule { get; set; }
    }
}
