
using ApiUi.Business;
using ApiUi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiUi;

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
        //We are injecting P1dbContext into MemoryDatabase so that we can read and access the database.
        //builder.Services.AddDbContext<P1dbContext>(options => options.UseInMemoryDatabase("P1dbContext"));
        builder.Services.AddDbContext<P1dbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("P1ApiConnectionString")));
        builder.Services.AddScoped<IAdminBL, AdminBL>();
        builder.Services.AddScoped<IUserBL, UserBL>();
        builder.Services.AddScoped<IReimbursementBL, ReimbursementBL>();

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
