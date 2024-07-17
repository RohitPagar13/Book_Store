using Business_Layer.Commands.Implementation;
using Business_Layer.Commands.Interface;
using Business_Layer.Queries.Implementation;
using Business_Layer.Queries.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Context;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Implementation;
using Repository_Layer.Service.Commands.Interface;
using Repository_Layer.Service.Handlers.Command.Implementation.BookCommand;
using Repository_Layer.Service.Handlers.Command.Implementation.UserCommand;
using Repository_Layer.Service.Handlers.Command.Interface;
using Repository_Layer.Service.Handlers.Query.Implementation.UserQuery;
using Repository_Layer.Service.Handlers.Query.Interface;
using Repository_Layer.Service.Queries.Implementation;
using Repository_Layer.Service.Queries.Query_Interface;
using System.Text;

namespace Book_Store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                //controllers
                builder.Services.AddControllers();

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();

                //Swagger JWT token
                builder.Services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Book_Store API",
                        Version = "v1"
                    });

                    // Add Bearer token authentication
                    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                        Description = "Please enter a valid token"
                    });

                    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
            {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                      Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
                });
                });

                //Sql Server
                builder.Services.AddDbContext<Book_Store_Context>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Book_Store"));
                });

                // Register repositories
                builder.Services.AddScoped<IUserCommandRL, UserCommandRL>();
                builder.Services.AddScoped<IUserQueryRL, UserQueryRL>();
                builder.Services.AddScoped<IBookCommandBL, BookCommandBL>();
                builder.Services.AddScoped<IBookQueryBL, BookQueryBL>();

                // Register handlers
                builder.Services.AddScoped<ICommandHandler<UserModel, UserResponseModel>, RegisterUserCommandHandler>();
                builder.Services.AddScoped<IQueryHandler<UserLoginModel, string>, LoginUserQueryHandler>();
                builder.Services.AddScoped<ICommandHandler<BookModel, BookEntity>,AddBookCommandHandler>();
                builder.Services.AddScoped<ICommandHandler<int, BookEntity>,DeleteBookCommandHandler>();
                builder.Services.AddScoped<IUpdateCommandHandler<int,BookModel, BookEntity>,UpdateBookCommandHandler>();

                // Register services
                builder.Services.AddScoped<IUserCommandBL, UserCommandBL>();
                builder.Services.AddScoped<IUserQueryBL, UserQueryBL>();
                builder.Services.AddScoped<IBookQueryBL,BookQueryBL>();
                builder.Services.AddScoped<IBookCommandBL,BookCommandBL>();

                //JWT Authentication
                var jwtSettings = builder.Configuration.GetSection("Jwt");
                var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidIssuer = jwtSettings["Issuer"],
                            ValidAudience = jwtSettings["Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(key)
                        };
                    });

                //Services Building
                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthentication();
                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}