using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
