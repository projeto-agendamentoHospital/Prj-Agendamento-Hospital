//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
//using AgendamentoHospital.Contexto;
//using System.Text;
//using System.Data.SqlClient;
//using Dapper;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

//namespace AgendamentoHospital.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SpecialtyController : ControllerBase
//    {

//        private readonly IConfiguration _configuration;
//        private readonly ProjetoContext _contexto;

//        public SpecialtyController(ProjetoContext context, IConfiguration configuration)
//        {
//            _contexto = context;
//            _configuration = configuration;
//        }


//        [HttpGet]
//        [Route("/GetList")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AgendamentoHospital.Entidade.Especialidade>))]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult GetList()
//        {

//            try
//            {
//                return Ok((from t in _contexto.Especialidades
//                           select t).ToList());
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpGet]
//        [Route("/GetbylistID/{Id}")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgendamentoHospital.Entidade.Especialidade))]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult GetbyId(int Id)
//        {

//            try
//            {
//                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));

//                AgendamentoHospital.Entidade.Especialidade especialidade =
//                    connection.Query<AgendamentoHospital.Entidade.Especialidade>
//                    ("SELECT [IdEspecialidade]" +
//                    "       ,[Nome]" +
//                    "       ,[Descricao]" +
//                    "       ,[Ativo]" +
//                    "        FROM Especialidade WHERE IdEspecialidade = @IdEspecialidade",
//                    new AgendamentoHospital.Entidade.Especialidade { IdEspecialidade = Id }).FirstOrDefault();

//                return Ok(especialidade);
                
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPost]
//        [Route("/CreateSpecialty")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult CadastratarEspecialista(AgendamentoHospital.Entidade.Especialidade especialidade)
//        {

//            try
//            {
//                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));


//                int linhasAfetadas = connection.Execute(
//                      "INSERT INTO [dbo].[Especialidade] " +
//                      "([Nome],[Descricao],[Ativo])" +
//                      "     VALUES(@Nome,@Descricao,@Ativo)", especialidade);

//                return Ok(linhasAfetadas);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpDelete]
//        [Route("/DeleteSpecialty/{Id}")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult Delete(int Id)
//        {

//            try
//            {
//                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));

//                var dynamicParameters = new DynamicParameters();
//                dynamicParameters.Add("@Id", Id);

//                int linhasAfetadas = connection.Execute(
//                    "DELETE FROM [dbo].[Especialidade] WHERE idEspecialidade = @Id", dynamicParameters);

//                return Ok(linhasAfetadas);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPatch]
//        [Route("/UpdateSpecialty")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult Update(AgendamentoHospital.Entidade.Especialidade especialidade)
//        {

//            try
//            {
//                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("Sql"));

//                int linhasAfetadas = connection.Execute(
//                    "UPDATE [dbo].[Especialidade] " +
//                    "SET [Nome] = @Nome " +
//                    "   ,[Descricao] = @Descricao " +
//                    "   ,[Ativo] = @Ativo " +
//                    "       WHERE idEspecialidade = @idEspecialidade", especialidade);

//                return Ok(linhasAfetadas);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }



//    }
//}
