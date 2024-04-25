using Microsoft.AspNetCore.Mvc;
using Simple_API_Assessment.Data.Repository;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantRepository applicantRepo;

        public ApplicantController(IApplicantRepository applicantRepository)
        {
            applicantRepo = applicantRepository;
        }

        ///// - Applicant end points - \\\\\\
        [HttpPost("/applicants")]
        public async Task<ActionResult> AddApplicant(Applicant applicant)
        {
            try
            {
                await applicantRepo.AddApplicant(applicant);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/applicants")]
        public async Task<ActionResult<List<Applicant>>> GetAllApplicants()
        {
            try
            {
                var applicants = await applicantRepo.GetApplicants();
                if(applicants.Count == 0) return NotFound();
                return Ok(applicants);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/applicants/{id}")]
        public async Task<ActionResult<Applicant>> GetApplicant(int id)
        {
            try
            {
                var applicant = await applicantRepo.GetApplicantById(id);
                if (applicant == null) return NotFound(applicant);
                return Ok(applicant);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("/applicants")]
        public async Task<ActionResult> UpdateApplicant(Applicant applicant)
        {
            try
            {
                await applicantRepo.UpdateApplicant(applicant);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("/applicants/{id}")]
        public async Task<ActionResult> DeleteApplicant(int id)
        {
            try
            {
                await applicantRepo.DeleteApplicant(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //////// - Skills end points - \\\\\\\\
        [HttpPost("/skills/{id}")]
        public async Task<ActionResult> Addskill(Skill skill, int id)
        {
            try
            {
                await applicantRepo.AddSkill(skill, id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/skills")]
        public async Task<ActionResult<List<Skill>>> GetAllSkills()
        {
            try
            {
                var skills = await applicantRepo.GetSkills();
                if(skills.Count == 0) return NotFound(skills);
                return Ok(skills);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/skills/{id}")]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            try
            {
                var skill = await applicantRepo.GetSkillById(id);
                if(skill == null) return NotFound();
                return Ok(skill);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("/skills")]
        public async Task<ActionResult> UpdateSkill(Skill skill)
        {
            try
            {
                await applicantRepo.UpdateSkill(skill);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("/skills/{id}")]
        public async Task<ActionResult> DeleteSkill(int id)
        {
            try
            {
                await applicantRepo.DeleteSkill(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}