using Luftborn.Application;
using Luftborn.Persistence;
namespace LuftbornTask
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
            // Add Modules Registrations
            builder.Services.AddApplicationService();
            //builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceService(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")  //Angular frontend URL
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            var app = builder.Build();
            app.UseCors("AllowSpecificOrigin");
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
        }
    }
}
