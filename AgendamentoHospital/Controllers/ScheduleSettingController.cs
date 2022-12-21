using AgendamentoHospital.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoHospital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleSettingController : Controller
    {
        private readonly ScheduleSettingRepository scheduleSettingRepository;
        public ScheduleSettingController()
        {
            scheduleSettingRepository = new ScheduleSettingRepository();
        }

        [HttpGet]
        public IActionResult Query()
        {
            try
            {
                var listScheduleSetting = scheduleSettingRepository.ListingSettingsData();
                return Ok(listScheduleSetting);
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
                var listScheduleSetting = scheduleSettingRepository.Query(id);
                if (listScheduleSetting.IdConfig != 0)
                {
                    return Ok(listScheduleSetting);
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
        public ActionResult Create(DTO.ScheduleSettingDto scheduleSetting)
        {
            try
            {
                scheduleSettingRepository.Create(scheduleSetting);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPut]
        public ActionResult Edit(DTO.ScheduleSettingDto schedule)
        {
            try
            {
                scheduleSettingRepository.Update(schedule);
                return Ok(schedule);
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
                scheduleSettingRepository.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }
    }
}
