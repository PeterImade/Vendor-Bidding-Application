
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Vendor_Bidding_Application.Configurations;
using Vendor_Bidding_Application.Contracts;
using Vendor_Bidding_Application.Data;
using Vendor_Bidding_Application.Models;
using Vendor_Bidding_Application.Repository;

namespace Vendor_Bidding_Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("66a90af64da3d22639cbfad9fec6adac3576c13867298f359e164bfdd89a3360"))
                };
            });

            var AllowAllOrigins = "AllowAllOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: AllowAllOrigins, policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IVendorRepository, VendorRepository>();
            builder.Services.AddScoped<IBidRepository, BidRepository>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("VendorDB"));
            });

            var app = builder.Build();
            
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (!dbContext.Vendors.Any())
                {
                    dbContext.Vendors.Add(new Vendor
                    {
                        Id = 1,
                        Name = "James Stuart",
                        Email = "jammiestuart@aol.com",
                        Password = "password123?",
                    });
                    dbContext.SaveChanges();
                }

                if (!dbContext.Projects.Any())
                {
                    dbContext.Projects.AddRange(new List<Project>
                    {
                        new Project {Id = 1, Name = "Project Alpha", Description = "A construction project for a new office building", Budget = 5000.00m, Currency = "USD", Category = "Construction"},
                        new Project { Id = 2, Name = "Project Beta", Description = "A marketing campaign for a new product launch", Budget = 2000.00m, Currency = "USD", Category = "Marketing" },
                        new Project { Id = 3, Name = "Project Gamma", Description = "Software development for a mobile app", Budget = 1500.00m, Currency = "EUR", Category = "Software" },
                        new Project { Id = 4, Name = "Project Delta", Description = "Renovation of a historical museum", Budget = 10000.00m, Currency = "GBP", Category = "Construction" },
                        new Project { Id = 5, Name = "Project Epsilon", Description = "Research project for AI technologies", Budget = 3000.00m, Currency = "USD", Category = "Research" },
                        new Project { Id = 6, Name = "Project Zeta", Description = "Branding and graphic design for a startup", Budget = 5000.00m, Currency = "JPY", Category = "Design" },
                        new Project { Id = 7, Name = "Project Eta", Description = "Web development for a new e-commerce platform", Budget = 1200.00m, Currency = "EUR", Category = "Software" },
                        new Project { Id = 8, Name = "Project Theta", Description = "Construction of a bridge over a river", Budget = 800.00m, Currency = "USD", Category = "Construction" },
                        new Project { Id = 9, Name = "Project Iota", Description = "Mobile game development", Budget = 2500.00m, Currency = "USD", Category = "Software" },
                        new Project { Id = 10, Name = "Project Kappa", Description = "Product development for a new consumer gadget", Budget = 1000.00m, Currency = "GBP", Category = "Product Design" }
                    });
                    dbContext.SaveChanges();
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(AllowAllOrigins);
            
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
