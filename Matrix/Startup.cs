﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;

namespace Matrix
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAuthRepository, AuthRepository>();

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("TokenSettings:JWTKey").Value);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options => {
                 options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });
            services.AddTransient<SeedDB>();
            services.AddMvc().AddJsonOptions(opt => {
                opt.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddCors();
            services.AddAutoMapper();
            //services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedDB seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //seeder.SeedUsers();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors(x => x.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials());
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapSpaFallbackRoute(
                name: "spa-fallback",
                defaults: new { controller = "Fallback", action = "Index" });
            });
        }
    }
}
