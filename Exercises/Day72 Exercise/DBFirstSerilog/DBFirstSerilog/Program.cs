
using DBFirstSerilog.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DBFirstSerilog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<MyAppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // 1. Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information() // Log Info, Warning, and Error
                .WriteTo.Console()          // Also show logs in the debug console
                .WriteTo.File("logs/myapp-.txt", rollingInterval: RollingInterval.Day) // Save to file
                .CreateLogger();

            // 2. Tell the Builder to use Serilog instead of the default logger
            builder.Host.UseSerilog();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // 3. Add Request Logging (Optional but highly recommended)
            // This logs every HTTP request (URL, Status Code, Time taken)
            app.UseSerilogRequestLogging();

            app.MapControllers();

            app.Run();
        }
    }
}
