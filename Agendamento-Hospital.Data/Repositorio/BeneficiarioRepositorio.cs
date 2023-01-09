using Agendamento_Hospital.Data.Dto;
using Agendamento_Hospital.Data.Interfaces;
using Agendamento_Hospital.Data.Entidades;


namespace Agendamento_Hospital.Data.Repositorio
{
    public class BeneficiarioRepositorio : IBeneficiaryRepositorio
    { 
        //injetando base
        private readonly Contexto.ProjetoContext _context;
        public BeneficiarioRepositorio(Contexto.ProjetoContext context)
        {
            _context = context;
        }

        //consultas 
        public List<BeneficiarioDto> GetAll()
        {
            return (from t in _context.Beneficiarios
                    select new BeneficiarioDto()
                    {
                        IdBeneficiary = t.IdBeneficiario,
                        Name = t.Nome,
                        Cpf = t.Cpf,
                        Phone = t.Telefone,
                        Address = t.Endereco,
                        NumberCard = t.NumeroCarteirinha,
                        Active = t.Ativo,
                        Email = t.Email,
                        Password = t.Senha
                    }).ToList();
            throw new NotImplementedException();
        }

         public BeneficiarioDto ListByID(int id)
        {
            return (from t in _context.Beneficiarios
                    where t.IdBeneficiario == id
                    select new BeneficiarioDto()
                    {
                        IdBeneficiary = t.IdBeneficiario,
                        Name = t.Nome,
                        Cpf = t.Cpf,
                        Phone = t.Telefone,
                        Address = t.Endereco,
                        NumberCard = t.NumeroCarteirinha,
                        Active = t.Ativo,
                        Email = t.Email,
                        Password = t.Senha

                    })
                    ?.FirstOrDefault()
                    ?? new BeneficiarioDto();
        }



        public int CreateBeneficiary(BeneficiarioDto cadastrarBeneficiarioDto)
        {
            Entidades.Beneficiario createBeneficiary = new Entidades.Beneficiario()
            {
                Nome = cadastrarBeneficiarioDto.Name,
                Cpf = cadastrarBeneficiarioDto.Cpf,
                Telefone = cadastrarBeneficiarioDto.Phone,
                Endereco = cadastrarBeneficiarioDto.Address,
                NumeroCarteirinha = cadastrarBeneficiarioDto.NumberCard,
                Ativo = cadastrarBeneficiarioDto.Active,
                Email = cadastrarBeneficiarioDto.Email,
                Senha = cadastrarBeneficiarioDto.Password,
            };

            _context.ChangeTracker.Clear();
            _context.Beneficiarios.Add(createBeneficiary);
            return _context.SaveChanges();
        }


        public int DeleteByID(int Id)
        {
            Beneficiario deleteBeneficiario =
                (from c in _context.Beneficiarios
                 where c.IdBeneficiario == Id
                 select c).FirstOrDefault();

            if (deleteBeneficiario == null || DBNull.Value.Equals(deleteBeneficiario.IdBeneficiario) || deleteBeneficiario.IdBeneficiario == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Beneficiarios.Remove(deleteBeneficiario);
            return _context.SaveChanges();
        }


        public int UpdateBeneficiary(BeneficiarioDto cadastrarBeneficiarioDto)
        {
            Beneficiario beneficiarioEntidadeBanco =
                (from c in _context.Beneficiarios
                 where c.IdBeneficiario == cadastrarBeneficiarioDto.IdBeneficiary
                 select c)
                 ?.FirstOrDefault()
                 ?? new Beneficiario();

            if (beneficiarioEntidadeBanco == null || DBNull.Value.Equals(beneficiarioEntidadeBanco.IdBeneficiario) || beneficiarioEntidadeBanco.IdBeneficiario == 0)
            {
                return 0;
            }

            beneficiarioEntidadeBanco.Nome = cadastrarBeneficiarioDto.Name;
            beneficiarioEntidadeBanco.Cpf = cadastrarBeneficiarioDto.Cpf;
            beneficiarioEntidadeBanco.Telefone = cadastrarBeneficiarioDto.Phone;
            beneficiarioEntidadeBanco.Endereco = cadastrarBeneficiarioDto.Address;
            beneficiarioEntidadeBanco.NumeroCarteirinha = cadastrarBeneficiarioDto.NumberCard;
            beneficiarioEntidadeBanco.Ativo = cadastrarBeneficiarioDto.Active;
            beneficiarioEntidadeBanco.Email = cadastrarBeneficiarioDto.Email;
            beneficiarioEntidadeBanco.Senha = cadastrarBeneficiarioDto.Password;

            _context.ChangeTracker.Clear();
            _context.Beneficiarios.Update(beneficiarioEntidadeBanco);
            return _context.SaveChanges();
        }


    }
}
