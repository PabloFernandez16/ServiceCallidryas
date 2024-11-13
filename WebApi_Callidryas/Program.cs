using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi_Callidryas;
using WebApi_Callidryas.Data;
using WebApi_Callidryas.Interfaces;
using WebApi_Callidryas.Models.Common;
using WebApi_Callidryas.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configuración de la cadena de conexión para MySQL
builder.Services.AddDbContext<CallidryasDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Configuración de CORS para permitir cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin() 
               .AllowAnyHeader() 
               .AllowAnyMethod(); 
    });
});

builder.Services.AddControllers();

//para inyectar al appsettings desde el appsettingsJson
var appSettingsSeccion = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSeccion);

#region JWT
//aqui va lo de json web token
// var appsettings = appSettingsSeccion.Get<AppSettings>();
// var llave = Encoding.ASCII.GetBytes(appsettings.Secreto);
// builder.Services.AddAuthentication(d =>
// {
//     d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
//     .AddJwtBearer(d =>
//     {
//         d.RequireHttpsMetadata = false;
//         d.SaveToken = true;
//         d.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(llave),
//             ValidateIssuer = false,
//             ValidateAudience = false
//         };
//     });
# endregion

//Dependencias inyectadas

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IMicroRepository, MicroRepository>();
builder.Services.AddScoped<IDriverVehicleCheckRepository, DriverVehicleCheckRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplica la política de CORS para permitir cualquier dominio
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
