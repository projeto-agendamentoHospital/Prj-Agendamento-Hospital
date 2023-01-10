using Microsoft.AspNetCore.Mvc;
using Agendamento_Hospital.Data.Dto;
using Agendamento_Hospital.Data.Interfaces;

namespace Projeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRespositorio _hospitalRespositorio;

        public HospitalController( IHospitalRespositorio hospitalRespositorio)
        {
            _hospitalRespositorio = hospitalRespositorio;   
        }


        [HttpGet]
        [Route("/GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {

            try
            { 
                return Ok(_hospitalRespositorio.ListarTodas());
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
                return Ok(_hospitalRespositorio.ListarPorId(idHospital));
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
        public IActionResult CadastrarHospital(HospitalDto hospital)
        {

            try
            {
                return Ok(_hospitalRespositorio.CadastrarHospital(hospital));

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
                return Ok(_hospitalRespositorio.ExcluirHospital(Id));
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
        public IActionResult Atualizar(HospitalDto hospital)
        {

            try
            {
                return Ok(_hospitalRespositorio.AtualizarHospital(hospital));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
