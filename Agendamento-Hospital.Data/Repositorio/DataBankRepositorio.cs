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
    public class DataBankRepositorio: IDataBankRepositorio
    {
        //injetando base
        private readonly Contexto.ProjetoContext _context;
        public DataBankRepositorio(Contexto.ProjetoContext context)
        {
            _context = context;
        }

        public List<DataBankDto> GetAll()
        {
            return (from t in _context.DadosBancarios
                    select new DataBankDto()
                    {
                        IdDataBank = t.IdDadosBancarios,
                        IdProfessional = t.IdProfissional,
                        NumberBank = t.NumeroBanco,
                        CodPix = t.CodigoPix,
                        Agency = t.Agencia,
                        AccountNumber = t.NumeroConta,
                        Savings = t.Poupanca                       
                    }).ToList();
            throw new NotImplementedException();
        }

        public DataBankDto ListByID(int id)
        {
            return (from t in _context.DadosBancarios
                    where t.IdDadosBancarios == id
                    select new DataBankDto()
                    {
                        IdDataBank = t.IdDadosBancarios,
                        IdProfessional = t.IdProfissional,
                        NumberBank = t.NumeroBanco,
                        CodPix = t.CodigoPix,
                        Agency = t.Agencia,
                        AccountNumber = t.NumeroConta,
                        Savings = t.Poupanca

                    })
                    ?.FirstOrDefault()
                    ?? new DataBankDto();
        }

        public int CreateDataBank(DataBankDto DadosBancariosDto)
        {
            DadosBancario createDataBank = new DadosBancario()
            {
                IdProfissional = DadosBancariosDto.IdProfessional,
                NumeroBanco = DadosBancariosDto.NumberBank,
                CodigoPix = DadosBancariosDto.CodPix,
                Agencia = DadosBancariosDto.Agency,
                NumeroConta = DadosBancariosDto.AccountNumber,
                Poupanca = DadosBancariosDto.Savings
            };

            _context.ChangeTracker.Clear();
            _context.DadosBancarios.Add(createDataBank);
            return _context.SaveChanges();
        }

        public int DeleteByID(int Id)
        {
            DadosBancario deleteDadosBancario =
                (from c in _context.DadosBancarios
                 where c.IdDadosBancarios == Id
                 select c).FirstOrDefault();

            if (deleteDadosBancario == null || DBNull.Value.Equals(deleteDadosBancario.IdDadosBancarios) || deleteDadosBancario.IdDadosBancarios == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.DadosBancarios.Remove(deleteDadosBancario);
            return _context.SaveChanges();
        }


        public int UpdateDataBank(DataBankDto cadastrarDadosBancarioDto)
        {
            DadosBancario dadosBancarioEntidadeBanco =
                (from c in _context.DadosBancarios
                 where c.IdDadosBancarios == cadastrarDadosBancarioDto.IdDataBank
                 select c)
                 ?.FirstOrDefault()
                 ?? new DadosBancario();

            if (dadosBancarioEntidadeBanco == null || DBNull.Value.Equals(dadosBancarioEntidadeBanco.IdDadosBancarios) || dadosBancarioEntidadeBanco.IdDadosBancarios == 0)
            {
                return 0;
            }

            dadosBancarioEntidadeBanco.Agencia = cadastrarDadosBancarioDto.Agency;
            dadosBancarioEntidadeBanco.NumeroBanco = cadastrarDadosBancarioDto.NumberBank;
            dadosBancarioEntidadeBanco.Poupanca = cadastrarDadosBancarioDto.Savings;
            dadosBancarioEntidadeBanco.CodigoPix = cadastrarDadosBancarioDto.CodPix;
            dadosBancarioEntidadeBanco.NumeroConta = cadastrarDadosBancarioDto.AccountNumber;
           
            _context.ChangeTracker.Clear();
            _context.DadosBancarios.Update(dadosBancarioEntidadeBanco);
            return _context.SaveChanges();
        }



    }
}
