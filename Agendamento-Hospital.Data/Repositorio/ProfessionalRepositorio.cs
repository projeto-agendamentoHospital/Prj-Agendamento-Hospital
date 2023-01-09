using Agendamento_Hospital.Data.Dto;
using Agendamento_Hospital.Data.Interfaces;


namespace Agendamento_Hospital.Data.Repositorio
{
    public class ProfessionalRepositorio : IProfessionalRepositorio
    {

        private readonly Contexto.ProjetoContext _context;
        public ProfessionalRepositorio(Contexto.ProjetoContext context)
        {
            _context = context;
        }

        public List<ProfessionalDto> GetAll()
        {
            return (from t in _context.Profissionals
                    select new ProfessionalDto()
                    {
                        IdProfessional = t.IdProfissional,
                        Name = t.Nome,                     
                        Phone = t.Telefone,
                        Address = t.Endereco,                        
                        Active = t.Ativo                       
                    }).ToList();
            throw new NotImplementedException();
        }

        public ProfessionalDto ListByID(int id)
        {
            return (from t in _context.Profissionals
                    where t.IdProfissional == id
                    select new ProfessionalDto()
                    {
                        IdProfessional = t.IdProfissional,
                        Name = t.Nome,                        
                        Phone = t.Telefone,
                        Address = t.Endereco,                       
                        Active = t.Ativo
                    })
                    ?.FirstOrDefault()
                    ?? new ProfessionalDto();
        }

        public int CreateProfessional(ProfessionalDto cadastrarProfessionalDto)
        {
            Entidades.Profissional createProfessional = new Entidades.Profissional()
            {
                Nome = cadastrarProfessionalDto.Name,                
                Telefone = cadastrarProfessionalDto.Phone,
                Endereco = cadastrarProfessionalDto.Address,                
                Ativo = cadastrarProfessionalDto.Active,               
            };

            _context.ChangeTracker.Clear();
            _context.Profissionals.Add(createProfessional);
            return _context.SaveChanges();
        }


        public int DeleteByID(int Id)
        {
            Entidades.Profissional deleteProfissional =
                (from c in _context.Profissionals
                 where c.IdProfissional == Id
                 select c).FirstOrDefault();

            if (deleteProfissional == null || DBNull.Value.Equals(deleteProfissional.IdProfissional) || deleteProfissional.IdProfissional == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Profissionals.Remove(deleteProfissional);
            return _context.SaveChanges();
        }


        public int UpdateProfessional(ProfessionalDto cadastrarProfessionalDto)
        {
            Entidades.Profissional profissionalEntidadeBanco =
                (from c in _context.Profissionals
                 where c.IdProfissional == cadastrarProfessionalDto.IdProfessional
                 select c)
                 ?.FirstOrDefault()
                 ?? new Entidades.Profissional();

            if (profissionalEntidadeBanco == null || DBNull.Value.Equals(profissionalEntidadeBanco.IdProfissional) || profissionalEntidadeBanco.IdProfissional == 0)
            {
                return 0;
            }

            profissionalEntidadeBanco.Nome = cadastrarProfessionalDto.Name;           
            profissionalEntidadeBanco.Telefone = cadastrarProfessionalDto.Phone;
            profissionalEntidadeBanco.Endereco = cadastrarProfessionalDto.Address;           
            profissionalEntidadeBanco.Ativo = cadastrarProfessionalDto.Active;
            

            _context.ChangeTracker.Clear();
            _context.Profissionals.Update(profissionalEntidadeBanco);
            return _context.SaveChanges();
        }




    }
}
