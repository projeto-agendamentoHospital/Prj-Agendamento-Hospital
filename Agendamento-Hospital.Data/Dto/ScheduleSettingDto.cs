using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Dto
{
    public class ScheduleSettingDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdScheduleSetting { get; set; }

        public int IdHospitalSetting { get; set; }

        public int IdSpecialtySetting { get; set; }

        public int IdProfissionalSetting { get; set; }

        public DateTime DataTimeSetting { get; internal set; }

        public DateTime DataTimeEndSetting { get; internal set; }
        
    }
}
