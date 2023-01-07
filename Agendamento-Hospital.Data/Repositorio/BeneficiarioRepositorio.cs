using Agendamento_Hospital.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Repositorio
{
    public class BeneficiarioRepositorio
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
            Entidades.Beneficiario deleteBeneficiario =
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





    }
}
