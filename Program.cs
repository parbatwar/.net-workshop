using Microsoft.EntityFrameworkCore;
using W18.Controllers;
using W18.Data;
using W18.Repositories.StudentRepository;
using W18.Services.StudentService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// PostgreSQL Database Service
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.Configure<MyInfoConfig>
    (builder.Configuration.GetSection(key: "MyInfo"));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
