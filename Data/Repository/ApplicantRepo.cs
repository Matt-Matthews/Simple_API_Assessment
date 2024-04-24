using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public class ApplicantRepo : IApplicantRepository
    {
        private readonly DataContext _context;

        public ApplicantRepo(DataContext context)
        {
            _context = context;
        }

        public async Task AddApplicant(Applicant applicant)
        {
            await _context.Applicants.AddAsync(applicant);
            await _context.SaveChangesAsync();
        }

        public async Task AddSkill(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteApplicant(int id)
        {
            var application = await _context.Applicants.FindAsync(id);
            _context.Applicants.Remove(application);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSkill(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }

        public async Task<Applicant> GetApplicantById(int id)
        {
            return await _context.Applicants.FindAsync(id);
        }

        public async Task<List<Applicant>> GetApplicants()
        {
            return await _context.Applicants.ToListAsync();
        }

        public async Task<Skill> GetSkillById(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<List<Skill>> GetSkills()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task UpdateApplicant(int id)
        {
            var applicant = await _context.Applicants.FindAsync(id);
            _context.Applicants.Update(applicant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSkill(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
        }
    }
}