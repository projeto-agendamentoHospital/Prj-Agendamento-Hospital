using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AgendamentoHospital.Contexto;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Projeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ProjetoContext _contexto;

        public HospitalController(ProjetoContext context, IConfiguration configuration)
        {
            _contexto = context;
            _configuration = configuration;
        }


        [HttpGet]
        [Route("/GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AgendamentoHospital.Entidade.Hospital>))]
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
        [Route("/GetbyIdHospital/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgendamentoHospital.Entidade.Hospital))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorId(int Id)
        {
            try
            {

                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));
               
                AgendamentoHospital.Entidade.Hospital hospital =
                    connection.Query<AgendamentoHospital.Entidade.Hospital>
                    ("Select" +
                    "[idHospital]" +
                    "    ,[Nome]" +
                    "    ,[CNPJ]" +
                    "    ,[Endereço]" +
                    "    ,[Telefone]" +
                    "    ,[CNES]" +
                    "    ,[Ativo] from Hospital WHERE idHospital = @idHospital",
                    new AgendamentoHospital.Entidade.Hospital {IdHospital = Id }).FirstOrDefault();

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
        public IActionResult ListarPorId(AgendamentoHospital.Entidade.Hospital hospital)
        {

            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));


                int linhasAfetadas = connection.Execute(
                      "INSERT INTO [dbo].[Hospital] " +
                      "([Nome],[CNPJ],[Endereço],[Telefone],[CNES],[Ativo])" +
                      "     VALUES(@Nome,@CNPJ,@Endereço,@Telefone,@CNES,@Ativo)", hospital);

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
        public IActionResult Atualizar(AgendamentoHospital.Entidade.Hospital hospital)
        {

            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                    "UPDATE [dbo].[Hospital] " +
                    "SET [Nome] = @Nome " +
                    "   ,[CNPJ] = @CNPJ " +
                    "   ,[Endereço] = @Endereço " +
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
