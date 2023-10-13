
using API_EF_NET7.Interfaces;
using API_EF_NET7.Models;
using API_EF_NET7.Respositories;
using Microsoft.EntityFrameworkCore;


public class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<ITeamRespository, TeamRespository>();
        // Bắt buộc phải đặt ở đây, nếu không sẽ lỗi : InvalidOperationException: The service collection cannot be modified because it is read-only. 
        //if (builder.Environment.IsDevelopment())
        //{

        builder.Services.AddDbContext<WCDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        //}
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        if (app.Environment.IsProduction())
        {
            Console.WriteLine("Test");
        }

        if (app.Environment.IsDevelopment())
        {
            // Connection DB

            app.UseSwagger();
            app.UseSwaggerUI();
        }



        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

}