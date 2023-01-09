using Agendamento_Hospital.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Interfaces
{
    public interface ISpecialtyRepositorio
    {
        public List<Dto.SpecialtyDto> GetAll();

        public SpecialtyDto GetbyId(int IdSpecialty);

        public int CreateSpecialty(SpecialtyDto specialtyDto);

        public int DeleteSpecialty(int IdSpecialty);

        public SpecialtyDto UpdateSpecialty(int IdSpecialty);

    }
}
