using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Dto
{
    public class ProfessionalDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProfessional { get; set; }       
        public string Name { get; set; }      
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
    }
}
