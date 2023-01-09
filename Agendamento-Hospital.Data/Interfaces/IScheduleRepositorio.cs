using Agendamento_Hospital.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Interfaces
{
    public interface IScheduleRepositorio
    {

        public List<Dto.ScheduleDto> GetSchedules();

        public ScheduleDto GetbyId(int id);

        public int CreateSchedule(ScheduleDto scheduleDto);

        public int DeleteSchedule(int IdSchedule);  

        public int UpdateSchedule(int Idschedule);
    }
}
