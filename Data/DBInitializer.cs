using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data
{
    public static class DBInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<DataContext>();
            var url = app.Configuration.GetConnectionString("DefaultConnection") ?? "Server=localhost:5432;User Id=Simple_API_user;Password=password;Database=Simple_API_DB";

            SeedData(_context, url);
        }
        private static void SeedData(DataContext context, string url)
        {
            context.Database.SetConnectionString(url);
            context.Database.Migrate();

            if (context.Applicants.Any()) //Checks if the data exist in the database
            {
                Console.WriteLine("Already have data");
                return;
            }

            var skills = new List<Skill>()
            {
                new() {
                    Name = "Docker",
                },
                new() {
                    Name = "C#",
                },
                new() {
                    Name = "React",
                },
            }; // create a list of skills

            context.Add(new Applicant
            {
                Name = "Mathews",
                Skills = skills
            }); //Add a new Applicant with three skills
            context.SaveChanges();

        }
    }
}