using System.Reflection;
using GlobalSolutionsET.Persistence;
using GlobalSolutionsET.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAnuncioRepository, AnuncioRepository>();
builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Global Solutions 2024 - Energy Transfer",
        Version = "v1",
        Description = "Documentação da Global Solutions 2024 para gerenciamento dos usuários, anúncios e pagamentos.",
        Contact = new OpenApiContact()
        {

            Name = "Equipe de Desenvolvimento Energy Transfer"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    swagger.IncludeXmlComments(xmlPath);
});


builder.Services.AddDbContext<FIAPDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleFIAPDbContext"));
});

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
