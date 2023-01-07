using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Agendamento_Hospital.Data;
using Agendamento_Hospital.Data.Contexto;

namespace Projeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly ProjetoContext _contexto;
        private readonly IConfiguration _configuration;
        

        public HospitalController(ProjetoContext context, IConfiguration configuration)
        {
            _contexto = context;
            _configuration = configuration;
        }


        [HttpGet]
        [Route("/GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Agendamento_Hospital.Data.Entidades.Hospital>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {

            try
            {
                return Ok((from t in _contexto.Hospitals
                           select t).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetbyIdHospital/{idHospital}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorId(int idHospital)
        {
            try
            {

                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("idHospital", idHospital);

                
               Agendamento_Hospital.Data.Entidades.Hospital hospital =
                    connection.Query<Agendamento_Hospital.Data.Entidades.Hospital>
                    ("Select" +
                    "[idHospital]" +
                    "    ,[Nome]" +
                    "    ,[CNPJ]" +
                    "    ,[Endereco]" +
                    "    ,[Telefone]" +
                    "    ,[CNES]" +
                    "    ,[Ativo] from Hospital WHERE idHospital = @idHospital",
                    dynamicParameters).FirstOrDefault();

                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/CreateHospital")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarHospital(Agendamento_Hospital.Data.Entidades.Hospital hospital)
        {

            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));


                int linhasAfetadas = connection.Execute(
                      "INSERT INTO [dbo].[Hospital] " +
                      "([Nome],[CNPJ],[Endereco],[Telefone],[CNES],[Ativo])" +
                      "     VALUES(@Nome,@CNPJ,@Endereco,@Telefone,@CNES,@Ativo)", hospital);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/DeleteHospital/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int Id)
        {

            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", Id);
               
                int linhasAfetadas = connection.Execute(
                    "DELETE FROM [dbo].[Hospital] WHERE idHospital = @Id", dynamicParameters);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/UpdateHospital")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(Agendamento_Hospital.Data.Entidades.Hospital hospital)
        {

            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                    "UPDATE [dbo].[Hospital] " +
                    "SET [Nome] = @Nome " +
                    "   ,[CNPJ] = @CNPJ " +
                    "   ,[Endereco] = @Endereco " +
                    "   ,[Telefone] = @Telefone " +
                    "   ,[CNES] = @CNES " +
                    "   ,[Ativo] = @Ativo " +
                    "       WHERE idHospital = @idHospital", hospital);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
