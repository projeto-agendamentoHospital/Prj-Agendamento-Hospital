
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Agendamento_Hospital.Data.Dto
{
    public class DataBankDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDataBank { get; set; }

        public string NumberBank { get; set; } = null!;

        public string? CodPix { get; set; }

        public string? Agency { get; set; }

        public string? AccountNumber { get; set; }

        public bool? Savings { get; set; }

        public int IdProfessional { get; set; }

    }
}
