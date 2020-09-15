using AutoMapper;
using System;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Taxi.API.Data;
using Taxi.API.Hubs;
using Taxi.API.Repositories;
using Taxi.Domain.DTO;
using Taxi.Domain.Interfaces;
using Taxi.Domain.Models;

namespace Taxi.API
{
    public class Startup
    {
        private string _connectionString;
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddDbContext<TaxiContext>(options =>
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("TaxiMacOS"))
                    {
                        UserID = Configuration["DbUsername"],
                        Password = Configuration["DbPassword"]
                    };

                    _connectionString = builder.ConnectionString;
                }
                else
                {
                    _connectionString = Configuration.GetConnectionString("Taxi");
                }
                
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(_connectionString);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;

            }).AddEntityFrameworkStores<TaxiContext>()
                .AddDefaultTokenProviders();

            services.AddSignalR(options =>
                {
                    options.EnableDetailedErrors = true;
                    options.KeepAliveInterval = TimeSpan.FromMinutes(1);
                }
            );
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Taxi! API",
                    Version = "v1"
                });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IRepository<Address>, AddressesRepository>();
            services.AddScoped<IMappingRepository<AddressDto>, AddressesRepository>();
            services.AddScoped<IRepository<Customer>, CustomersRepository>();
            services.AddScoped<IMappingRepository<CustomerDto>, CustomersRepository>();
            services.AddScoped<IRepository<Driver>, DriversRepository>();
            services.AddScoped<IMappingRepository<DriverDto>, DriversRepository>();
            services.AddScoped<IRepository<Company>, CompaniesRepository>();
            services.AddScoped<IMappingRepository<CompanyDto>, CompaniesRepository>();
            services.AddScoped<IRepository<Order>, OrdersRepository>();
            services.AddScoped<IMappingRepository<OrderDto>, OrdersRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Taxi! API");
                options.RoutePrefix = string.Empty;
            });
            app.UseCors("DefaultPolicy");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<TaxiHub>("/taxiHub");
            });
        }
    }
}
