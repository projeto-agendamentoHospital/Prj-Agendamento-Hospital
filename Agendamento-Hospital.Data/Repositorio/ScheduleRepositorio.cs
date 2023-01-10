using Agendamento_Hospital.Data.Dto;
using Agendamento_Hospital.Data.Entidades;
using Agendamento_Hospital.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Repositorio
{
    public class ScheduleRepositorio : IScheduleRepositorio
    {
        private readonly Contexto.ProjetoContext _context;

        public ScheduleRepositorio(Contexto.ProjetoContext context)
        {
            this._context = context;
        }
        public List<ScheduleDto> GetSchedules()
        {
            return (from t in _context.Agendamentos
                    select new ScheduleDto()
                    {
                        IdSchedule = t.IdAgendamento,
                        IdHospitalSchedule = t.IdHospital,
                        IdSpecialtySchedule = t.IdEspecialidade,
                        IdProfissionalSchedule = t.IdProfissional,
                        DataHoraSchedule = t.DataHoraAgendamento,
                        IdBeneficiarySchedule = t.IdBeneficiario,
                        AtivoSchedule = t.Ativo,
                    }).ToList();

            throw new NotImplementedException();
        }

        public ScheduleDto GetbyId(int IdSchedule)
        {
            return (from t in _context.Agendamentos
                    where t.IdAgendamento == IdSchedule
                    select new ScheduleDto()
                    {
                        IdSchedule = t.IdAgendamento,
                        IdHospitalSchedule = t.IdHospital,
                        IdSpecialtySchedule = t.IdEspecialidade,
                        IdProfissionalSchedule = t.IdProfissional,
                        DataHoraSchedule = t.DataHoraAgendamento,
                        IdBeneficiarySchedule = t.IdBeneficiario,
                        AtivoSchedule = t.Ativo,
                    }).FirstOrDefault();


            throw new NotImplementedException();
        }

        public int CreateSchedule(ScheduleDto scheduleDto)
        {
            Entidades.Agendamento agendamento = new Entidades.Agendamento();
            {
                agendamento.IdHospital = scheduleDto.IdHospitalSchedule;
                agendamento.IdEspecialidade = scheduleDto.IdSpecialtySchedule;
                agendamento.IdProfissional = scheduleDto.IdProfissionalSchedule;
                agendamento.DataHoraAgendamento = scheduleDto.DataHoraSchedule;
                agendamento.IdBeneficiario = scheduleDto.IdBeneficiarySchedule;
                agendamento.Ativo = scheduleDto.AtivoSchedule;
            };
            _context.ChangeTracker.Clear();
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();

            throw new NotImplementedException();
        }

        public int DeleteSchedule(int IdSchedule)
        {
            Agendamento deleteAgendamento =
              (from c in _context.Agendamentos
               where c.IdAgendamento == IdSchedule
               select c).FirstOrDefault();

            if (deleteAgendamento == null || DBNull.Value.Equals(deleteAgendamento.IdAgendamento) ||
                deleteAgendamento.IdAgendamento == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Agendamentos.Remove(deleteAgendamento);
            return _context.SaveChanges();

            throw new NotImplementedException();
        }

        public int UpdateSchedule(ScheduleDto IdSchedule)
        {
            Agendamento agendamento =
                (from c in _context.Agendamentos
                 where c.IdAgendamento == IdSchedule.IdSchedule
                 select c)
                 ?.FirstOrDefault()
                 ?? new Agendamento();

            if (agendamento == null || DBNull.Value.Equals(agendamento.IdAgendamento) || agendamento.IdAgendamento == 0)
            {
                return 0;
            }

            agendamento.IdHospital = IdSchedule.IdHospitalSchedule;
            agendamento.IdEspecialidade = IdSchedule.IdSpecialtySchedule;
            agendamento.IdProfissional = IdSchedule.IdProfissionalSchedule;
            agendamento.DataHoraAgendamento = IdSchedule.DataHoraSchedule;
            agendamento.IdBeneficiario = IdSchedule.IdBeneficiarySchedule;
            agendamento.Ativo = IdSchedule.AtivoSchedule;


            _context.ChangeTracker.Clear();
            _context.Agendamentos.Update(agendamento);
            return _context.SaveChanges();


            throw new NotImplementedException();
        }
    }
}
