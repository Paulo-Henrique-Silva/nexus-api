
using Microsoft.EntityFrameworkCore;
using NexusAPI.Compartilhado.Data;

namespace NexusAPI
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

            string conexao = "Server=(localdb)\\MSSQLLocalDB;Database=BDNEXUS;Trusted_Connection=True;MultipleActiveResultSets=True";

            builder.Services.AddDbContext<DataContext>(obj => obj.UseSqlServer(conexao));

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
        }
    }
}
