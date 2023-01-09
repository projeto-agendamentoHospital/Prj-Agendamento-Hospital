using Agendamento_Hospital.Data.Dto;
using Agendamento_Hospital.Data.Entidades;
using Agendamento_Hospital.Data.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoHospital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleProfessionalRegistrationController : Controller
    {
        private readonly Agendamento_Hospital.Data.Interfaces.IProfessionalRepositorio _profissionalRepositorio;
        public ScheduleProfessionalRegistrationController(Agendamento_Hospital.Data.Interfaces.IProfessionalRepositorio professionalRepositorio)
        {
            _profissionalRepositorio = professionalRepositorio;
        }

        [HttpGet]
        [Route("/GetAllProfessional")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProfessionalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_profissionalRepositorio.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("/GetProfessionalbyId/{idProfissional}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        public ActionResult ListByID(int idProfissional)
        {
            try
            {
                return Ok(_profissionalRepositorio.ListByID(idProfissional));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("/CreateProfessional")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateProfessional(ProfessionalDto cadastrarProfissional)
        {
            try
            {
                int resultado = _profissionalRepositorio.CreateProfessional(cadastrarProfissional);

                if (cadastrarProfissional == null || String.IsNullOrEmpty(cadastrarProfissional.Name))
                    return NoContent();

                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        [Route("/UpdateProfessional")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateProfessional(ProfessionalDto cadastrarProfissional)
        {
            try
            {
                return Ok(_profissionalRepositorio.UpdateProfessional(cadastrarProfissional));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        [Route("/DeleteProfessional/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteByID(int Id)
        {
            try
            {
                return Ok(_profissionalRepositorio.DeleteByID(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
