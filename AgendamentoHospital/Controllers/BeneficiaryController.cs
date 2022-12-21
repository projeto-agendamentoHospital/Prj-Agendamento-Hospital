using AgendamentoHospital.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoHospital.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly BeneficiaryRepository beneficiaryRepository;

        public BeneficiaryController()
        {
            beneficiaryRepository= new BeneficiaryRepository();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listBeneficiary = beneficiaryRepository.GetBeneficiaryData();
                return Ok(listBeneficiary);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("/GetByID/{id}")]
        public ActionResult GetBeneficiaryByID(int id) {

            try
            {
                var listBeneficiary = beneficiaryRepository.GetByID(id);
                if (listBeneficiary.IdBeneficiary != 0)
                {
                    return Ok(listBeneficiary);
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
        [Route("/CreateBeneficiary")]
        public ActionResult CreateBeneficiary(DTO.BeneficiaryDto beneficiary)
        {
            try
            {
                beneficiaryRepository.Create(beneficiary);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }



        [HttpPut]
        [Route("/UpdateBeneficiary/{id}")]
        public ActionResult UpdateBeneficiary(DTO.BeneficiaryDto beneficiary)
        {
            try
            {
                beneficiaryRepository.UpdateBeneficiary(beneficiary);
                return Ok(beneficiary);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("/DeleteBeneficiary")]
        public ActionResult DeleteBeneficiary(int id)
        {
            try
            {
                beneficiaryRepository.DeleteBeneficiary(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }

        }

    }
}
