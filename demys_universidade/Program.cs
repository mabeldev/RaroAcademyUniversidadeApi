#region BuilderServices


using demys_universidade.Domain.Interfaces.Repositories;
using demys_universidade.Domain.Interfaces.Services;
using demys_universidade.Domain.Services;
using demys_universidade.Domain.Settings;
using demys_universidade.Filters;
using demys_universidade.Infrastructure.Contexts;
using demys_universidade.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

#region SwaggerDoc
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1",
                        new Microsoft.OpenApi.Models.OpenApiInfo
                        {
                            Title = "demys_universidade",
                            Version = "v1",
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "Mabel" },
                            TermsOfService = new Uri("http://raroacademy.com")
                        });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    swagger.IncludeXmlComments(xmlPath);
});
#endregion

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ExceptionFilter));
    options.Filters.Add(typeof(ValidationFilter));
});

#endregion

#region AppSettings

var appSetting = builder.Configuration.GetSection(nameof(AppSetting)).Get<AppSetting>();
builder.Services.AddSingleton(appSetting);

#endregion

#region Mapper

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion

#region Services

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();

#endregion

#region Repositories

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();

#endregion

#region Dbcontext

builder.Services.AddDbContext<UniversidadeContext>(options =>
{
    options.UseSqlServer(appSetting.SqlServerConnection);
    options.UseLazyLoadingProxies();
});

#endregion

#region HttpClient

builder.Services.AddHttpClient<IBrasilCepRepository, BrasilCepRepository>(options =>
{
    options.BaseAddress = new Uri(appSetting.ApiCep);
});

#endregion

#region AppConfiguration

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion