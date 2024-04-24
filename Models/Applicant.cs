

namespace Simple_API_Assessment.Models
{
    public class Applicant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }
    }
}