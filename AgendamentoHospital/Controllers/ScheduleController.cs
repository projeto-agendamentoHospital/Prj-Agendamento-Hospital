using Microsoft.AspNetCore.Mvc;
using Agendamento_Hospital.Data.Dto;
using Agendamento_Hospital.Data.Interfaces;
using Agendamento_Hospital.Data.Repositorio;


namespace AgendamentoHospital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepositorio _scheduleRepositorio;

        public ScheduleController(IScheduleRepositorio scheduleRepositorio)
        {
            _scheduleRepositorio = scheduleRepositorio;
        }

        [HttpGet]
        [Route("/GetAllSchedules")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ScheduleDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSchedules()
        {

            try
            {
                return Ok(_scheduleRepositorio.GetSchedules());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetbyIdSchedule/idShedule")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorId(int idShedule)
        {
            try
            {
                return Ok(_scheduleRepositorio.GetbyId(idShedule));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/CreateSchedule")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarHospital(ScheduleDto scheduleDto)
        {

            try
            {
                return Ok(_scheduleRepositorio.CreateSchedule(scheduleDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/DeleteSchedule/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int Id)
        {

            try
            {
                return Ok(_scheduleRepositorio.DeleteSchedule(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/UpdateSchedule")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(ScheduleDto scheduleDto)
        {

            try
            {
                return Ok(_scheduleRepositorio.UpdateSchedule(scheduleDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
