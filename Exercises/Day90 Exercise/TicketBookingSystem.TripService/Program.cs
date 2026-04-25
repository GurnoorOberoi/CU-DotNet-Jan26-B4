using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TicketBookingSystem.TripService.Data;
using TicketBookingSystem.TripService.Repositories;
using TicketBookingSystem.TripService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TripDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TripDbContext") ??
        throw new InvalidOperationException("Connection string 'TripDbContext' not found.")));

builder.Services.AddHttpClient("ItineraryService", c =>
{
    c.BaseAddress = new Uri("https://localhost:5005/"); // your itinerary service port
});

// JWT configuration

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "")
                )
            };
        }
    );

// Add services to the container.

builder.Services.AddAuthorization();

builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<ITripService, TicketBookingSystem.TripService.Services.TripService>();

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

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
