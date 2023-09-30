using Microsoft.EntityFrameworkCore;
using User.Application.Servise;
using User.Infrastructure.DB;
using User.Infrastructure.Servise;

namespace User;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // //builder.Services.AddScoped<IUserCRUD<Domain.Entity.User>,UserCRUD>();

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<IUserCRUD<Domain.Entity.User>, UserCRUD>();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<IMyDbcontext, MyDbcontext>(option => option.UseNpgsql(builder.Configuration.GetSection("MyConnections")["MyDbcontext"]));
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