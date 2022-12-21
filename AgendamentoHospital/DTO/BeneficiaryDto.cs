namespace AgendamentoHospital.DTO
{
    public class BeneficiaryDto
    {
        public int IdBeneficiary { get; set; }

        public string Name { get; set; } = null!;

        public string Cpf { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string NumberCard { get; set; } = null!;

        public bool Active { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
