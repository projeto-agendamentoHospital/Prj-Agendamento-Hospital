using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AgendamentoHospital.Contexto;
using System.Text;
using System.Data.SqlClient;
using Dapper;

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
        [Route("/ListarTodos")]
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
        [Route("/ListarHospital/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgendamentoHospital.Entidade.Hospital))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorId(int Id)
        {

            try
            {
                return Ok((from t in _contexto.Hospitals
                           select t).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/CadastrarHospital")]
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
        [Route("/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(AgendamentoHospital.Entidade.Hospital hospital)
        {

            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                    "DELETE FROM [dbo].[Hospital] WHERE idHospital = @idHospital", hospital);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/Atualizar")]
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
