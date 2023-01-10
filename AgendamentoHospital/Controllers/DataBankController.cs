using Agendamento_Hospital.Data.Dto;
using Agendamento_Hospital.Data.Entidades;
using Agendamento_Hospital.Data.Interfaces;
using Agendamento_Hospital.Data.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoHospital.Controllers
{
    public class DataBankController : ControllerBase
    {
        private readonly Agendamento_Hospital.Data.Interfaces.IDataBankRepositorio _dadosBancarioRepositorio;

        public DataBankController(Agendamento_Hospital.Data.Interfaces.IDataBankRepositorio dataBankRepositorio)
        {
            _dadosBancarioRepositorio = dataBankRepositorio;
        }

        [HttpGet]
        [Route("/GetAllDataBank")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DataBankDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {

            try
            {
                return Ok(_dadosBancarioRepositorio.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("/GetbyId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListByID(int id)
        {
            try
            {
                return Ok(_dadosBancarioRepositorio.ListByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("/CreateDataBank")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateDataBank(DataBankDto DadosBancario)
        {
            try
            {
                return Ok(_dadosBancarioRepositorio.CreateDataBank(DadosBancario));              
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpDelete]
        [Route("/DeleteDataBank/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteByID(int Id)
        {

            try
            {
                return Ok(_dadosBancarioRepositorio.DeleteByID(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        [Route("/UpdateDataBank")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateDataBank(DataBankDto dataBank)
        {
            try
            {
                return Ok(_dadosBancarioRepositorio.UpdateDataBank(dataBank));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
