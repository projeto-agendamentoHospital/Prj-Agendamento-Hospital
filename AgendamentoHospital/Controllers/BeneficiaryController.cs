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
        private readonly Agendamento_Hospital.Data.Interfaces.IBeneficiaryRepositorio _beneficiarioRepositorio;


        public BeneficiaryController(Agendamento_Hospital.Data.Interfaces.IBeneficiaryRepositorio beneficiaryRepositorio)
        {
            _beneficiarioRepositorio = beneficiaryRepositorio;
        }

        [HttpGet]
        [Route("/GetAllBeneficiary")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BeneficiarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {

            try
            {
                return Ok( _beneficiarioRepositorio.GetAll());
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
                return Ok(_beneficiarioRepositorio.ListByID(idBeneficiario));
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
        public IActionResult CreateBeneficiary(BeneficiarioDto cadastrarBeneficiario)
        {
            try
            {
                int resultado = _beneficiarioRepositorio.CreateBeneficiary(cadastrarBeneficiario);

                if (cadastrarBeneficiario == null || String.IsNullOrEmpty(cadastrarBeneficiario.Name))
                    return NoContent();

                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
                return Ok(_beneficiarioRepositorio.DeleteByID(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        [Route("/UpdateBeneficiary")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateBeneficiary(BeneficiarioDto cadastrarBeneficiario)
        {

            try
            {
                return Ok(_beneficiarioRepositorio.UpdateBeneficiary(cadastrarBeneficiario));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
