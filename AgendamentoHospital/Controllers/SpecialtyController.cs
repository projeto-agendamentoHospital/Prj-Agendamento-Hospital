using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Agendamento_Hospital.Data.Interfaces;
using Agendamento_Hospital.Data.Dto;

namespace AgendamentoHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyRepositorio _specialtyRepositorio;

        public SpecialtyController(ISpecialtyRepositorio specialtyRepositorio )
        {
            _specialtyRepositorio = specialtyRepositorio;
        }


        [HttpGet]
        [Route("/GetList")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Agendamento_Hospital.Data.Entidades.Especialidade>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetList()
        {

            try
            {
                return Ok(_specialtyRepositorio.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetbylistID/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetbyId(int Id)
        {

            try
            {
                return Ok(_specialtyRepositorio.GetbyId(Id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/CreateSpecialty")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateSpecialty(SpecialtyDto specialty)
        {

            try
            {
                return Ok(_specialtyRepositorio.CreateSpecialty(specialty));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/DeleteSpecialty/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteSpecialty(int Id)
        {

            try
            {
                return Ok(_specialtyRepositorio.DeleteSpecialty(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/UpdateSpecialty")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateSpecialty(int Id)
        {

            try
            {
                return Ok(_specialtyRepositorio.UpdateSpecialty(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
