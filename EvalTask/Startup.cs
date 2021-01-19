using System;
using AutoMapper;
using EvalTask.API.Extensions;
using EvalTask.Data;
using EvalTask.Domain.Entities;
using EvalTask.Features.UploadServices;
using EvalTask.Features.UploadServices.Base;
using EvalTask.Features.UploadServices.Interfaces;
using EvalTask.Features.UploadServices.Product;
using EvalTask.Identity;
using EvalTask.Services.Mapping;
using EvalTask.Swagger;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Spells.Extensions;

namespace EvalTask.API
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
            services.AddDbContext<EvalTaskContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddDefaultIdentity<User>(ConfigureIdentity)
                .AddEntityFrameworkStores<EvalTaskContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IdentityDbContext<User>, EvalTaskContext>();
            // services.AddTransient<UploadStarter>();
            services.AddScoped<IUploader, FileUploader>();
            // services.AddTransient(typeof(IUploadStarter<>),typeof(UploadStarter<>));
            // services.AddTransient(typeof(IUploader<>),typeof(FileUploader<>));
            services.AddScoped<ICsvFileParser<Product>, CsvProductParserService>();
            services.AddScoped<IJsonFileParser<Product>, JsonProductParserService>();
            
            
            
            services.Do(ConfigureAuthentication);
            
            services.AddScoped<IMediator, Mediator>();
            
            services.Do(ConfigureMediatorHandlers);

            services.Do(ConfigureMapping);
            
            services.AddControllers();
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            
            app.UseHangfireDashboard();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        
        private void ConfigureMediatorHandlers(IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.Load("EvalTask.Features"));
        }
        
        private void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddConfig<JwtOptions>(Configuration, "Identity:Jwt", out var jwtOptions);
            services.AddSingleton<JwtGenerator>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Audience = jwtOptions.Audience; 
                    options.ClaimsIssuer = jwtOptions.Issuer;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        
                        IssuerSigningKey = jwtOptions.GetSecurityKey(),
                        
                        RequireExpirationTime = true,
                        // ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();
        }
        
        private void ConfigureIdentity(IdentityOptions options)
        {
            options.SignIn.RequireConfirmedEmail = false;
            options.User.RequireUniqueEmail = true;
            
            options.Password.RequiredLength = 5;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        }

        private void ConfigureMapping(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<ProductProfile>();
                config.AddProfile<UserProfile>();
                config.AddProfile<CategoryProfile>();
            });
        }

    }
}