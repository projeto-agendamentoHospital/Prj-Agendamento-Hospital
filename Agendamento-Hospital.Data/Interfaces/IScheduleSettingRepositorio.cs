using Agendamento_Hospital.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Interfaces
{
    public interface IScheduleSettingRepositorio
    {

        public List<Dto.ScheduleSettingDto> GetSchedulesSetting();

        public ScheduleSettingDto GetbyIdSetting(int id);

        public int CreateScheduleSetting(ScheduleSettingDto scheduleSettingDto);

        public int DeleteScheduleSetting(int IdScheduleSetting);

        public int UpdateScheduleSetting(ScheduleSettingDto scheduleDto);

    }
}
