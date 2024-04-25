using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public interface IApplicantRepository
    {
        //for applicant
        Task AddApplicant(Applicant applicant);
        Task<List<Applicant>> GetApplicants();
        Task<Applicant> GetApplicantById(int id);
        Task UpdateApplicant(Applicant applicant);
        Task DeleteApplicant(int id);

        //for skills
        Task AddSkill(Skill skill, int id);
        Task<List<Skill>> GetSkills();
        Task<Skill> GetSkillById(int id);
        Task UpdateSkill(Skill skill);
        Task DeleteSkill(int id);
    }
}