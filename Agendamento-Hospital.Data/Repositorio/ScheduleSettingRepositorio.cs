using Agendamento_Hospital.Data.Contexto;
using Agendamento_Hospital.Data.Dto;
using Agendamento_Hospital.Data.Entidades;
using Agendamento_Hospital.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agendamento_Hospital.Data.Repositorio
{
    public class ScheduleSettingRepositorio : IScheduleSettingRepositorio
    {
        private readonly Contexto.ProjetoContext _context;

        public ScheduleSettingRepositorio(ProjetoContext projetoContext)
        {
            _context = projetoContext;
        }

        public List<ScheduleSettingDto> GetSchedulesSetting()
        {
            return (from t in _context.AgendamentoConfiguracaos
                    select new ScheduleSettingDto()
                    {
                        IdScheduleSetting = t.IdConfiguracao,
                        IdHospitalSetting = t.IdHospital,
                        IdSpecialtySetting = t.IdEspecialidade,
                        IdProfissionalSetting = t.IdProfissional,
                        DataTimeSetting = t.DataHoraInicioAtendimento,
                        DataTimeEndSetting = t.DataHoraFinalAtendimento,
                    }).ToList();

            throw new NotImplementedException();
        }
        public ScheduleSettingDto GetbyIdSetting(int IdScheduleSetting)
        {
            return (from t in _context.AgendamentoConfiguracaos
                    where t.IdConfiguracao == IdScheduleSetting
                    select new ScheduleSettingDto()
                    {
                        IdScheduleSetting = t.IdConfiguracao,
                        IdHospitalSetting = t.IdHospital,
                        IdSpecialtySetting = t.IdEspecialidade,
                        IdProfissionalSetting = t.IdProfissional,
                        DataTimeSetting = t.DataHoraInicioAtendimento,
                        DataTimeEndSetting = t.DataHoraFinalAtendimento,
                    }).FirstOrDefault();

            throw new NotImplementedException();
        }

        public int CreateScheduleSetting(ScheduleSettingDto scheduleSettingDto)
        {
            AgendamentoConfiguracao agendamentoConfiguracao = new AgendamentoConfiguracao();
            {
               agendamentoConfiguracao.IdConfiguracao = scheduleSettingDto.IdScheduleSetting;
               agendamentoConfiguracao.IdHospital = scheduleSettingDto.IdHospitalSetting;
               agendamentoConfiguracao.IdEspecialidade = scheduleSettingDto.IdSpecialtySetting;
               agendamentoConfiguracao.IdProfissional = scheduleSettingDto.IdProfissionalSetting;
               agendamentoConfiguracao.DataHoraInicioAtendimento = scheduleSettingDto.DataTimeSetting;
               agendamentoConfiguracao.DataHoraFinalAtendimento = scheduleSettingDto.DataTimeEndSetting;
            };
            _context.ChangeTracker.Clear();
            _context.AgendamentoConfiguracaos.Add(agendamentoConfiguracao);
            _context.SaveChanges();


            throw new NotImplementedException();
        }

        public int DeleteScheduleSetting(int IdScheduleSetting)
        {
            AgendamentoConfiguracao deleteAgendamentoConfiguracao =
                  (from c in _context.AgendamentoConfiguracaos
                   where c.IdConfiguracao == IdScheduleSetting
                   select c).FirstOrDefault();

            if (deleteAgendamentoConfiguracao == null || DBNull.Value.Equals(deleteAgendamentoConfiguracao.IdConfiguracao) ||
                deleteAgendamentoConfiguracao.IdConfiguracao == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.AgendamentoConfiguracaos.Remove(deleteAgendamentoConfiguracao);
            return _context.SaveChanges();


            throw new NotImplementedException();
        }


        public int UpdateScheduleSetting(int IdscheduleSetting)
        {
            throw new NotImplementedException();
        }
    }
}
