using Microsoft.AspNetCore.Mvc;
using Agendamento_Hospital.Data.Dto;
using Agendamento_Hospital.Data.Interfaces;
using Agendamento_Hospital.Data.Repositorio;

namespace AgendamentoHospital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchuduleSettingController : ControllerBase
    {
        private readonly IScheduleSettingRepositorio _scheduleSettingRepositorio;

        public SchuduleSettingController(IScheduleSettingRepositorio scheduleSettingRepositorio)
        {
            _scheduleSettingRepositorio= scheduleSettingRepositorio;
        }

        [HttpGet]
        [Route("/GetAllSchedulesSetting")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ScheduleSettingDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSchedulesSetting()
        {

            try
            {
                return Ok(_scheduleSettingRepositorio.GetSchedulesSetting());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetbyIdScheduleSetting/idShedule")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorId(int idShedule)
        {
            try
            {
                return Ok(_scheduleSettingRepositorio.GetbyIdSetting(idShedule));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/CreateScheduleSetting")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarHospital(ScheduleSettingDto scheduleSettingDto)
        {

            try
            {
                return Ok(_scheduleSettingRepositorio.CreateScheduleSetting(scheduleSettingDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/DeleteScheduleSetting/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int Id)
        {

            try
            {
                return Ok(_scheduleSettingRepositorio.DeleteScheduleSetting(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/UpdateScheduleSetting")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(ScheduleDto scheduleDto)
        {

            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
