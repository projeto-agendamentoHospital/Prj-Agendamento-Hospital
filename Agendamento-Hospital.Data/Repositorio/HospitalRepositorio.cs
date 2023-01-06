using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Repositorio
{
    public class HospitalRepositorio
    {

        private readonly Contexto.ProjetoContext _context;
        public HospitalRepositorio(Contexto.ProjetoContext context) 
        {
            _context = context;
        }

        public List<Dto.HospitalDto> ListarTodas()
        {
            return (from t in _context.Hospitals
                    select new Dto.HospitalDto()
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
    }
}
