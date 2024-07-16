using Business_Layer.Commands.Implementation;
using Business_Layer.Commands.Interface;
using Microsoft.EntityFrameworkCore;
using Model_Layer.QueryModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Context;
using Repository_Layer.Service.Commands.Implementation;
using Repository_Layer.Service.Commands.Interface;
using Repository_Layer.Service.Handlers.Command.Implementation;
using Repository_Layer.Service.Handlers.Command.Interface;

namespace Book_Store
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

            builder.Services.AddDbContext<Book_Store_Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Book_Store"));
            });

            // Register repositories
            builder.Services.AddScoped<IUserCommandRL, UserCommandRL>();
            //builder.Services.AddScoped<IUserQueryRepository, UserQueryRepository>();

            // Register handlers
            builder.Services.AddScoped<ICommandHandler<UserModel,UserResponseModel>, RegisterUserCommandHandler>();
            //builder.Services.AddScoped<IQueryHandler<GetUserByEmailQuery, User>, GetUserByEmailQueryHandler>();

            // Register services
            builder.Services.AddScoped<IUserCommandBL, UserCommandBL>();
            //builder.Services.AddScoped<IUserQueryService, UserQueryService>();
            //services.AddScoped<IAuthService, AuthService>();

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