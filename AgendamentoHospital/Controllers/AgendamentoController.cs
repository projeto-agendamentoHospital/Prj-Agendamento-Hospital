using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AgendamentoHospital.Contexto;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using AgendamentoHospital.Entidade;

namespace AgendamentoHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ProjetoContext _contexto;

        public AgendamentoController(ProjetoContext context, IConfiguration configuration)
        {
            _contexto = context;
            _configuration = configuration;
        }


        [HttpGet]
        [Route("/GetAllScheduling")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AgendamentoHospital.Entidade.Agendamento>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodosAgendamento()
        {

            try
            {
                return Ok((from t in _contexto.Agendamentos
                           select t).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetbyIdScheduling/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgendamentoHospital.Entidade.Agendamento))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorId(int Id)
        {
            try
            {

                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));

                AgendamentoHospital.Entidade.Agendamento agendamento =
                    connection.Query<AgendamentoHospital.Entidade.Agendamento>
                    ("SELECT [idAgendamento]," +
                    "   [idHospital]," +
                    "   [idEspecialidade]," +
                    "   [idProfissional]," +
                    "   [DataHoraAgendamento]," +
                    "   [idBeneficiario]," +
                    "   [Ativo]  " +
                    "       FROM Agendamento WHERE idAgendamento = @IdAgendamento",
                    new AgendamentoHospital.Entidade.Agendamento { IdAgendamento = Id }).FirstOrDefault();

                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/CreateScheduling")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarHospital(AgendamentoHospital.Entidade.Agendamento agendamento)
        {

            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));


                int linhasAfetadas = connection.Execute(
                      "INSERT INTO [dbo].[Agendamento] " +
                      "([idHospital],[idEspecialidade],[idProfissional],[DataHoraAgendamento],[idBeneficiario],[Ativo])" +
                      "     VALUES((@idHospital,@idEspecialidade,@idProfissional,@DataHoraAgendamento,@idBeneficiario,@Ativo)", agendamento);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/DeleteScheduling/{Id}")]
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
                    "DELETE FROM [dbo].[Agendamento] WHERE idAgendamento = @Id", dynamicParameters);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/UpdateScheduling")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AtualizarAgendamento(AgendamentoHospital.Entidade.Agendamento agendamento)
        {

            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                  "UPDATE[dbo].[Agendamento]" +
                  "SET[idHospital] = @idHospital" +
                  ",[idEspecialidade] = @idEspecialidade" +
                  ",[idProfissional] = @idProfissional" + 
                  ",[DataHoraAgendamento] = @DataHoraAgendamento" +
                  ",[idBeneficiario] = @idBeneficiario" +
                  ",[Ativo] = @Ativo " +
                  "WHERE idAgendamento = @idAgendamento", agendamento);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
