using AgendamentoHospital.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoHospital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : Controller
    {
        private readonly ScheduleRepository scheduleRepository;

        public ScheduleController()
        {
            scheduleRepository = new ScheduleRepository();
        }

        [HttpGet]
        public IActionResult Query()
        {
            try
            {
                var listSchedule = scheduleRepository.ListingSchedules();
                return Ok(listSchedule);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Query/{id}")]
        public ActionResult Query(int id)
        {
            try
            {
                var listSchedule = scheduleRepository.Query(id);
                if (listSchedule.IdSchedule != 0)
                {
                    return Ok(listSchedule);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Create(DTO.ScheduleDto scheduleDto)
        {
            try
            {
                scheduleRepository.CreateSchedule(scheduleDto);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

        }
        [HttpPut]
        public ActionResult Edit(DTO.ScheduleDto scheduleDto)
        {
            try
            {
                scheduleRepository.Update(scheduleDto);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                scheduleRepository.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }
    }
}
