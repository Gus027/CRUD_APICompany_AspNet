using ApiCompany.Infraestructure;
using ApiCompany.Infraestructure.Repository;
using ApiCompany.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

builder.Services.AddDbContext<CompanyContext>(options => options.UseNpgsql(configuration.GetConnectionString("default"))); ;

builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
