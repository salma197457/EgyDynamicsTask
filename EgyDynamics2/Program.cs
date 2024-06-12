
using EgyDynamics2.Config;
using EgyDynamics2.Models;
using EgyDynamics2.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EgyDynamics2
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

            //_______________________DB___________________//
            builder.Services.AddDbContext<EgyDynamicsContext>(op =>
                op.UseSqlServer(builder.Configuration.GetConnectionString("con")));

            //_______________________Injection___________________//
            builder.Services.AddScoped<UnitOf_Work>();

            //_______________________AutoMapper___________________//
            builder.Services.AddAutoMapper(typeof(AutoMap).Assembly);
            //--------------------- Define CORS policy name ---------------------//
            string corsPolicyName = "AllowAll";

            //--------------------- Add CORS policy ---------------------//
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName, builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            //------------------------validate token------------------------//

            builder.Services.AddAuthentication(option => option.DefaultAuthenticateScheme = "myscheme")
                .AddJwtBearer("myscheme",
                //validate token
                op =>
                {
                    #region secret key
                    string key = "welcome to my secret key PetBook Alex";
                    var secertkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                    #endregion
                    op.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = secertkey,
                        ValidateIssuer = false,
                        ValidateAudience = false

                    };
                }
                );


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            //--------------------- Use CORS policy ---------------------//
            app.UseCors(corsPolicyName);


            app.MapControllers();

            app.Run();
        }
    }
}
