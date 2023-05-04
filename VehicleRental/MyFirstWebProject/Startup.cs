using BL_;
using DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MyFirstWebProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins("http://aaa.com", "http://bbb.com");
                });
            });
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("key").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers();
            services.AddScoped<ICustomer_DL, Customer_DL>();
            services.AddScoped<ICustomer_Bl, Customer_Bl>();
            services.AddScoped<IDescVehicle_DL, DescVehicle_DL>();
            services.AddScoped<IDescVehicle_BL, DescVehicle_BL>();
            services.AddScoped<IOrders_BL, Orders_BL>();
            services.AddScoped<IOrders_DL, OrdersDL>();
            services.AddScoped<IStation_BL, Station_BL>();
            services.AddScoped<IStation_DL, Station_DL>();
            services.AddScoped<IDesigns_BL, Designs_BL>();
            services.AddScoped<IDesigns_DL, Designs_DL>();
            services.AddScoped<IRating_DL, Rating_DL>();
            services.AddScoped<IRating_BL, Rating_BL>();
            services.AddScoped<IPasswordHashHelper,PasswordHashHelper>();
            services.AddDbContext<VehicleRentals_dbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("vehicleRental")));
            services.AddResponseCaching();
            services.AddAutoMapper(typeof(Startup));
            //srv2\\pupils  //LAPTOP - ODKQSO4A
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyFirstWebProject", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, VehicleRentals_dbContext context,ILogger<Startup> logger)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFirstWebProject v1"));
            }

            app.UseCors(AllowSpecificOrigins);
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add(
                    "Content-Security-Policy", 
                    "default-src 'self';"+
                    "style-src 'self';"+
                    "img-src 'self'");
                await next();
            });
            logger.LogInformation("server is up");
            app.UseErrorMiddleware();
            app.UseRatingMiddleware();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //context.Database.EnsureCreated();

            app.UseAuthentication();
            app.UseRouting();
            app.UseResponseCaching();
            app.UseAuthorization();
           
            app.Map("/api/Customer", appUser =>
            {

                appUser.UseRouting();
               // appUser.UseRatingMiddleware();
                appUser.UseAuthorization();
         
                appUser.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            });

            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(10)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });
            //  app.UseRatingMiddleware();
            app.Map("/api", app2 =>
            {
                app2.UseRouting();
               // app2.UseRatingMiddleware();
                app2.UseAuthorization();
                app2.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });

            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
