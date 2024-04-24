using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public interface IApplicantRepository
    {
        //for applicant
        Task AddApplicant(Applicant applicant);
        Task<List<Applicant>> GetApplicants();
        Task<Applicant> GetApplicantById(int id);
        Task UpdateApplicant(int id);
        Task DeleteApplicant(int id);

        //for skills
        Task AddSkill(Skill skill);
        Task<List<Skill>> GetSkills();
        Task<Skill> GetSkillById(int id);
        Task UpdateSkill(int id);
        Task DeleteSkill(int id);
    }
}