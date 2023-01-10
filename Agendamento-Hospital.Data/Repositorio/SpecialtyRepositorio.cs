using Agendamento_Hospital.Data.Dto;
using Agendamento_Hospital.Data.Entidades;
using Agendamento_Hospital.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Repositorio
{
    public class SpecialtyRepositorio : ISpecialtyRepositorio
    {
        private readonly Contexto.ProjetoContext _context;
        public SpecialtyRepositorio(Contexto.ProjetoContext context)
        {
            _context = context;
        }
        public List<SpecialtyDto> GetAll()
        {
            return (from t in _context.Especialidades
                    select new SpecialtyDto()
                    {
                        IdSpecialty = t.IdEspecialidade,
                        NomeSpecialy = t.Nome,
                        DescricaoSpecialy = t.Descricao,
                        AtivoSpecialy = t.Ativo,
                    }).ToList();
            throw new NotImplementedException();
        }

        public SpecialtyDto GetbyId(int IdSpecialty)
        {
            return (from t in _context.Especialidades
                    where t.IdEspecialidade == IdSpecialty
                    select new SpecialtyDto()
                    {
                        IdSpecialty = t.IdEspecialidade,
                        NomeSpecialy = t.Nome,
                        DescricaoSpecialy = t.Descricao,
                        AtivoSpecialy = t.Ativo,
                    }).FirstOrDefault();

            throw new NotImplementedException();
        }

        public int CreateSpecialty(SpecialtyDto cadastrarDto)
        {
            Entidades.Especialidade specialty = new Entidades.Especialidade()
            {
                Nome = cadastrarDto.NomeSpecialy,
                Descricao = cadastrarDto.DescricaoSpecialy,
                Ativo = cadastrarDto.AtivoSpecialy
            };
            _context.ChangeTracker.Clear();
            _context.Especialidades.Add(specialty);
            return _context.SaveChanges();

            throw new NotImplementedException();
        }

        public int DeleteSpecialty(int IdSpecialty)
        {
            Especialidade deleteEspecialidade =
              (from c in _context.Especialidades
               where c.IdEspecialidade == IdSpecialty
               select c).FirstOrDefault();

            if (deleteEspecialidade == null || DBNull.Value.Equals(deleteEspecialidade.IdEspecialidade) ||
                deleteEspecialidade.IdEspecialidade == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Especialidades.Remove(deleteEspecialidade);
            return _context.SaveChanges();

            throw new NotImplementedException();
        }

        public int UpdateSpecialty(SpecialtyDto specialtyDto)
        {
            Especialidade especialidade =
            (from c in _context.Especialidades
             where c.IdEspecialidade == specialtyDto.IdSpecialty
             select c)
             ?.FirstOrDefault()
             ?? new Entidades.Especialidade(); 
           
            if (especialidade == null || DBNull.Value.Equals(especialidade.IdEspecialidade) || especialidade.IdEspecialidade == 0)
            {
                return 0;
            }

            especialidade.IdEspecialidade = specialtyDto.IdSpecialty;
            especialidade.Nome = specialtyDto.NomeSpecialy;
            especialidade.Descricao = specialtyDto.DescricaoSpecialy;
            especialidade.Ativo = specialtyDto.AtivoSpecialy;

            _context.ChangeTracker.Clear();
            _context.Especialidades.Update(especialidade);
            return _context.SaveChanges();
        }
    }
}
