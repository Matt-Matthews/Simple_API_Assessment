using Microsoft.EntityFrameworkCore;

namespace Simple_API_Assessment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}