using Agendamento_Hospital.Data.Dto;
using Agendamento_Hospital.Data.Interfaces;
using Agendamento_Hospital.Data.Entidades;
using System.Security.Cryptography;

namespace Agendamento_Hospital.Data.Repositorio
{
    public class HospitalRepositorio : IHospitalRespositorio
    {

        private readonly Contexto.ProjetoContext _context;
        public HospitalRepositorio(Contexto.ProjetoContext context) 
        {
            _context = context;
        }

        public List<Dto.HospitalDto> ListarTodas()
        {
            return (from t in _context.Hospitals
                    select new HospitalDto()
                    {
                        Identificado = t.IdHospital,
                        NomeHospital = t.Nome,
                        CnpjHospital = t.Cnpj,
                        EnderecoHospital = t.Endereco,
                        TelefoneHospital = t.Telefone,
                        CnesHospital = t.Cnes,
                        AtivoHospital = t.Ativo,
                    }).ToList();
            throw new NotImplementedException();
        }

        public HospitalDto ListarPorId(int id)
        {
            return (from t in _context.Hospitals
                    where t.IdHospital == id
                    select new HospitalDto()
                    {
                        Identificado = t.IdHospital,
                        NomeHospital = t.Nome,
                        CnpjHospital = t.Cnpj,
                        EnderecoHospital = t.Endereco,
                        TelefoneHospital = t.Telefone,
                        CnesHospital = t.Cnes,
                        AtivoHospital = t.Ativo,
                    }).FirstOrDefault();
            throw new NotImplementedException();
        }

        public int CadastrarHospital(Dto.HospitalDto hospitalDto)
        {
            Entidades.Hospital hospital = new Entidades.Hospital()
            {
                Nome = hospitalDto.NomeHospital,
                Cnpj = hospitalDto.CnpjHospital,
                Endereco = hospitalDto.EnderecoHospital,
                Telefone = hospitalDto.TelefoneHospital,
                Cnes = hospitalDto.CnesHospital,
                Ativo = hospitalDto.AtivoHospital,
            };
            _context.ChangeTracker.Clear();
            _context.Hospitals.Add(hospital);
            return _context.SaveChanges();
        }

        public int ExcluirHospital(int IdHospital)
        {
                Hospital  deleteHospital =
                (from c in _context.Hospitals
                 where c.IdHospital == IdHospital
                 select c).FirstOrDefault();

            if (deleteHospital == null || DBNull.Value.Equals(deleteHospital.IdHospital) ||
                deleteHospital.IdHospital == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Hospitals.Remove(deleteHospital);
            return _context.SaveChanges();
        }
        public int AtualizarHospital(HospitalDto AtualizaHospital)
        {
            Hospital hospital =
                 (from c in _context.Hospitals
                  where c.IdHospital == AtualizaHospital.Identificado
                  select c)
                  ?.FirstOrDefault()
                  ?? new Hospital();
                
            if (hospital == null || DBNull.Value.Equals(hospital.IdHospital) || hospital.IdHospital == 0)
            {
                return 0;
            }

            hospital.Nome = AtualizaHospital.NomeHospital;
            hospital.Cnpj = AtualizaHospital.CnpjHospital;
            hospital.Endereco = AtualizaHospital.EnderecoHospital;
            hospital.Telefone = AtualizaHospital.TelefoneHospital;
            hospital.Cnes = AtualizaHospital.CnesHospital;
            hospital.Ativo = AtualizaHospital.AtivoHospital;

            _context.ChangeTracker.Clear();
            _context.Hospitals.Update(hospital);
            return _context.SaveChanges();
        }
    }
}
