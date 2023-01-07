using AgendamentoHospital.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Agendamento_Hospital.Data.Contexto;
using Dapper;
using Agendamento_Hospital.Data.Dto;



namespace AgendamentoHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly ProjetoContext _contexto;
        private readonly IConfiguration _configuration;

        public BeneficiaryController(ProjetoContext context, IConfiguration configuration)
        {
            _contexto = context;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("/GetAllBeneficiary")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Agendamento_Hospital.Data.Entidades.Beneficiario>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {

            try
            {
                return Ok((from t in _contexto.Beneficiarios
                           select t).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetbyId/{idBeneficiario}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListByID(int idBeneficiario)
        {
            try
            {

                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("idBeneficiario", idBeneficiario);


                Agendamento_Hospital.Data.Entidades.Beneficiario beneficiario =
                     connection.Query<Agendamento_Hospital.Data.Entidades.Beneficiario>

                     ("Select" +
                     "[idBeneficiario]" +
                     "    ,[Nome]" +
                     "    ,[Cpf]" +
                     "    , [Telefone]" +
                     "    ,[Endereco]" +
                     "    ,[Telefone]" +
                     "    ,[NumeroCarteirinha]" +
                     "    ,[Email]" +
                     "    ,[Senha]" +
                     "    ,[Ativo] from Beneficiario WHERE idBeneficiario = @idBeneficiario",
                     dynamicParameters).FirstOrDefault();

                return Ok(beneficiario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("/CreateBeneficiary")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateBeneficiary(Agendamento_Hospital.Data.Entidades.Beneficiario beneficiario)
        {
            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));


                int linhasAfetadas = connection.Execute(
                      "INSERT INTO [dbo].[Beneficiario] " +
                      "([Nome],[Cpf],[Telefone],[Endereco],[NumeroCarteirinha],[Email],[Senha],[Ativo])" +
                      "     VALUES(@Nome,@Cpf,@Telefone,@Endereco,@NumeroCarteirinha,@Email,@Senha,@Ativo)", beneficiario);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("/DeleteBeneficiary/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteByID(int Id)
        {

            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", Id);

                int linhasAfetadas = connection.Execute(
                    "DELETE FROM [dbo].[Beneficiario] WHERE idBeneficiario = @Id", dynamicParameters);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/UpdateBeneficiary")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(Agendamento_Hospital.Data.Entidades.Beneficiario beneficiario)
        {

            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                    "UPDATE [dbo].[Beneficiario] " +
                    "SET [Nome] = @Nome " +
                    "   ,[Cpf] = @Cpf " +
                    "   ,[Telefone] = @Telefone " +
                    "   ,[Endereco] = @Endereco " +
                    "   ,[NumeroCarteirinha] = @NumeroCarteirinha " +
                    "   ,[Email] = @Email " +
                     "  ,[Senha] = @Senha " +
                    "   ,[Ativo] = @Ativo " +
                    "       WHERE idBeneficiario = @idBeneficiario", beneficiario);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
