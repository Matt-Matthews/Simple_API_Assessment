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
            await _context.Applicants.AddAsync(applicant); // Add an applicant with or without a list of skills
            await _context.SaveChangesAsync();
        }

        public async Task AddSkill(Skill skill, int id)
        {
            var applicant = await _context.Applicants.Include(a => a.Skills).FirstOrDefaultAsync(a => a.Id == id);
            applicant.Skills.Add(skill); //find an applicant by the id provided and add a new skill to the list of skills
            await _context.SaveChangesAsync();
        }

        public async Task DeleteApplicant(int id)
        {
            var application = await _context.Applicants.FindAsync(id); //find the applicant to be deleted
            _context.Applicants.Remove(application); //delete an applicant by id
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSkill(int id)
        {
            var skill = await _context.Skills.FindAsync(id); //find the skill to be deleted
            _context.Skills.Remove(skill); // delete a skill by id
            await _context.SaveChangesAsync();
        }

        public async Task<Applicant> GetApplicantById(int id)
        {
            return await _context.Applicants.Include(a => a.Skills).FirstOrDefaultAsync(a => a.Id == id);
        } // find an applicant by id with the applicant's skills

        public async Task<List<Applicant>> GetApplicants()
        {
            return await _context.Applicants.Include(a => a.Skills).ToListAsync();
        } //return a list of all applicants with their skills

        public async Task<Skill> GetSkillById(int id)
        {
            return await _context.Skills.FindAsync(id);
        } //find and returns a skill by id

        public async Task<List<Skill>> GetSkills()
        {
            return await _context.Skills.ToListAsync();
        }// return all the skills

        public async Task UpdateApplicant(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
            await _context.SaveChangesAsync();
        } //updates an applicant by an Id within the applicant object

        public async Task UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
        }//updates a skill by an Id within the skill object
    }
}