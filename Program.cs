using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using esluzba.DataAccess.Abstract;
using esluzba.DataAccess.DbContexts;
using esluzba.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.WriteIndented = true;
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddSwaggerGen();


builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddSingleton<IJwtAuth, JwtAuth>();

builder.Services.AddDbContext<UserContext>(options => options.UseNpgsql(builder.Configuration["ConnectionString"]!)); 
builder.Services.AddScoped<IUnitOfWork, UserContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization(config =>
{
    config.AddPolicy(JwtPolicies.Admin, JwtPolicies.AdminPolicy());
    config.AddPolicy(JwtPolicies.User, JwtPolicies.UserPolicy());
});
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Is Working");

app.Run();


