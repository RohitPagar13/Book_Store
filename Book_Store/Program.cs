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
using Repository_Layer.Service.Commands.Command_Interface;
using Repository_Layer.Service.Commands.Implementation;
using Repository_Layer.Service.Commands.Interface;
using Repository_Layer.Service.Handlers.Command.Implementation.AdminCommand;
using Repository_Layer.Service.Handlers.Command.Implementation.BookCommand;
using Repository_Layer.Service.Handlers.Command.Implementation.UserCommand;
using Repository_Layer.Service.Handlers.Command.Interface;
using Repository_Layer.Service.Handlers.Query.Implementation.Book;
using Repository_Layer.Service.Handlers.Query.Implementation.UserQuery;
using Repository_Layer.Service.Handlers.Query.Implementation.AdminQuery;
using Repository_Layer.Service.Handlers.Query.Interface;
using Repository_Layer.Service.Queries.Implementation;
using Repository_Layer.Service.Queries.Query_Interface;
using System.Text;
using Repository_Layer.Service.Handlers.Command.Implementation.UserDetailsCommand;
using Repository_Layer.Service.Handlers.Command.Implementation.CartCommand;
using Repository_Layer.Service.Handlers.Query.Implementation.CartQuery;
using Repository_Layer.Service.Handlers.Command.Implementation.WishListCommand;
using Repository_Layer.Service.Handlers.Query.Implementation.WishListQuery;
using Repository_Layer.Models;
using Repository_Layer.Service.Handlers.Command.Implementation.OrderCommand;
using Repository_Layer.Service.Handlers.Query.Implementation.OrderQuery;

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
                builder.Services.AddScoped<IBookCommandRL, BookCommandRL>();
                builder.Services.AddScoped<IBookQueryRL, BookQueryRL>();
                builder.Services.AddScoped<IAdminCommandRL, AdminCommandRL>();
                builder.Services.AddScoped<IAdminQueryRL, AdminQueryRL>();
                builder.Services.AddScoped<IUserDetailsCommandRL, UserDetailsCommandRL>();
                builder.Services.AddScoped<ICartCommandRL, CartCommandRL>();
                builder.Services.AddScoped<ICartQueryRL, CartQueryRL>();
                builder.Services.AddScoped<IWishListCommandRL, WishListCommandRL>();
                builder.Services.AddScoped<IWishListQueryRL, WishListQueryRL>();
                builder.Services.AddScoped<IOrderCommandRL, OrderCommandRL>();
                builder.Services.AddScoped<IOrderQueryRL, OrderQueryRL>();

                // Register handlers 
                builder.Services.AddScoped<ICommandHandler<UserModel, UserResponseModel>, RegisterUserCommandHandler>();
                builder.Services.AddScoped<IQueryHandler<UserLoginModel, string>, LoginUserQueryHandler>();
                builder.Services.AddScoped<IUpdateCommandHandler<string, string, string>, ResetUserCommandHandler>();
                builder.Services.AddScoped<IQueryHandler<string, string>, ForgotUserQueryHandler>();
                builder.Services.AddScoped<ICommandHandler<BookModel, BookEntity>,AddBookCommandHandler>();
                builder.Services.AddScoped<ICommandHandler<int, BookEntity>,DeleteBookCommandHandler>();
                builder.Services.AddScoped<IUpdateCommandHandler<int,BookModel, BookEntity>,UpdateBookCommandHandler>();
                builder.Services.AddScoped<IQueryHandler<int,BookEntity>,GetBookByIdQueryHandler>();
                builder.Services.AddScoped<IGetAllQueryHandler<List<BookEntity>>,GetAllBooksQueryHandler>();
                builder.Services.AddScoped<ICommandHandler<AdminModel, AdminResponseModel>, RegisterAdminCommandHandler>();
                builder.Services.AddScoped<IQueryHandler<AdminLoginModel, string>, LoginAdminQueryHandler>();
                builder.Services.AddScoped<ICommandHandler<UserDetailsClaimsModel, UserDetailsEntity>, AddUserDetailsCommandHandler>();
                builder.Services.AddScoped<ICommandHandler<CartModel, CartEntity>, AddToCartCommandHandler >();
                builder.Services.AddScoped<ICommandHandler<int,CartEntity>, DeleteCartCommandHandler >();
                builder.Services.AddScoped<IUpdateCommandHandler<int,int,CartEntity>, UpdateCartCommandHandler >();
                builder.Services.AddScoped<IQueryHandler<int, CartResponseModel>, GetCartsForUserQueryHandler>();
                builder.Services.AddScoped<ICommandHandler<WishListModel,WishListEntity>,AddToWishListCommandHandler >();
                builder.Services.AddScoped<ICommandHandler<int, WishListEntity>, RemoveFromWishListCommandHandler>();
                builder.Services.AddScoped<IQueryHandler<int,List<WishListEntity>>,GetWishListForUserQueryHandler>();
                builder.Services.AddScoped<ICommandHandler<PlaceOrderModel, OrderResponseModel>, PlaceOrderCommandHandler>();
                builder.Services.AddScoped<ICommandHandler<BuyNowModel, OrderEntity>, BuyNowCommandHandler>();
                builder.Services.AddScoped<ICommandHandler<int, OrderEntity>, CancelOrderCommandHandler>();
                builder.Services.AddScoped<IQueryHandler<int,List<OrderEntity>>, GetOrdersForUserQueryHandler>();


                // Register services
                builder.Services.AddScoped<IUserCommandBL, UserCommandBL>();
                builder.Services.AddScoped<IUserQueryBL, UserQueryBL>();
                builder.Services.AddScoped<IBookQueryBL,BookQueryBL>();
                builder.Services.AddScoped<IBookCommandBL,BookCommandBL>();
                builder.Services.AddScoped<IAdminCommandBL, AdminCommandBL>();
                builder.Services.AddScoped<IAdminQueryBL, AdminQueryBL>();
                builder.Services.AddScoped<IUserDetailsCommandBL, UserDetailsCommandBL>();
                builder.Services.AddScoped<ICartCommandBL, CartCommandBL>();
                builder.Services.AddScoped<ICartQueryBL, CartQueryBL>();
                builder.Services.AddScoped<IWishListCommandBL, WishListCommandBL>();
                builder.Services.AddScoped<IWishListQueryBL, WishListQueryBL>();
                builder.Services.AddScoped<IOrderCommandBL, OrderCommandBL>();

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