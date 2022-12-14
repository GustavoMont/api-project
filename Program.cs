using System.Text;
using api_project.Data;
using api_project.Repositories;
using api_project.Secret;
using api_project.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(Settings.Secret);

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddScoped<ProfessionalRepository>();
builder.Services.AddScoped<ServiceTypeRepository>();
builder.Services.AddScoped<ServiceRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<FirmRepository>();
builder.Services.AddScoped<ProfessionalServices>();
builder.Services.AddScoped<ServiceTypeService>();
builder.Services.AddScoped<ServiceServices>();
builder.Services.AddScoped<ClientServices>();
builder.Services.AddScoped<FirmServices>();
builder.Services.AddScoped<TokenService>();
builder.Services
    .AddAuthentication(auth =>
    {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(auth =>
    {
        auth.RequireHttpsMetadata = false;
        auth.SaveToken = true;
        auth.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddDbContext<Context>(
    options =>
        options.UseMySql(
            builder.Configuration.GetConnectionString("ConexaoBanco"),
            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoBanco"))
        )
);

builder.Services.AddControllers();

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

app.UseHttpsRedirection();

app.UseCors(cors =>
{
    cors.AllowAnyHeader();
    cors.AllowAnyHeader();
    cors.AllowAnyOrigin();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
