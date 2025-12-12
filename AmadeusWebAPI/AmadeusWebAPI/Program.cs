using AmadeusWebAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddJsonOptions(
        opciones => opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer("name=DefaultConnection"));

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
   .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.MapInboundClaims = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwtKey"]!)),
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", policy =>
        policy.RequireRole("Admin"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var allowOrigin = builder.Configuration.GetValue<string>("AllowOrigin")!.Split(",");
builder.Services.AddCors(opciones => 
{
    opciones.AddDefaultPolicy(politic =>
    {
        politic.WithOrigins(allowOrigin).AllowAnyHeader().AllowAnyMethod();

    });

});


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","API"));

app.MapGroup("/identity").MapIdentityApi<IdentityUser>();
app.Run();
