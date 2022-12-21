using AgendamentoHospital.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoHospital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleProfessionalRegistrationController : Controller
    {
        private readonly ScheduleProfessionalRegistrationRepository scheduleProfessionalRegistrationRepository;
        public ScheduleProfessionalRegistrationController()
        {
            scheduleProfessionalRegistrationRepository = new ScheduleProfessionalRegistrationRepository();
        }

        [HttpGet]
        public IActionResult ListingProfessionalRegistration()
        {
            try
            {
                var listScheduleProfessionalRegistration = scheduleProfessionalRegistrationRepository.ListingProfessionalRegistrationData();
                return Ok(listScheduleProfessionalRegistration);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetProfessionalRegistrationById/{id}")]
        public ActionResult GetProfessionalRegistrationById(int id)
        {
            try
            {
                var listScheduleProfessionalRegistration = scheduleProfessionalRegistrationRepository.GetProfessionalRegistrationById(id);
                if (listScheduleProfessionalRegistration.IdProfessional != 0)
                {
                    return Ok(listScheduleProfessionalRegistration);
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
        [Route("CreateProfessionalRegistration/")]
        public ActionResult CreateProfessionalRegistration(DTO.ScheduleProfessionalRegistrationDto scheduleProfessionalRegistration)
        {
            try
            {
                scheduleProfessionalRegistrationRepository.CreateProfessionalRegistration(scheduleProfessionalRegistration);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("UpdateProfessionalRegistration/")]
        public ActionResult UpdateProfessionalRegistration(DTO.ScheduleProfessionalRegistrationDto scheduleProfessionalRegistration)
        {
            try
            {
                scheduleProfessionalRegistrationRepository.UpdateProfessionalRegistration(scheduleProfessionalRegistration);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("DeleteProfessionalRegistration/{id}")]
        public ActionResult DeleteProfessionalRegistration(int id)
        {
            try
            {
                var listScheduleProfessionalRegistration = scheduleProfessionalRegistrationRepository.GetProfessionalRegistrationById(id);
                if (listScheduleProfessionalRegistration.IdProfessional != 0)
                {
                    scheduleProfessionalRegistrationRepository.DeleteProfessionalRegistration(listScheduleProfessionalRegistration.IdProfessional);
                    return Ok(listScheduleProfessionalRegistration);
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
    }
}
