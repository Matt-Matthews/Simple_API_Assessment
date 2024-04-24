using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Data;
using Simple_API_Assessment.Data.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IApplicantRepository, ApplicantRepo>();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

try{
    DBInitializer.InitDb(app);

}catch (Exception e)
{
    Console.WriteLine(e);
}

app.MapControllers();

app.Run();
