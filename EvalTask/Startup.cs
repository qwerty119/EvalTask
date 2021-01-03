using System;
using EvalTask.API.Extensions;
using EvalTask.Data;
using EvalTask.Domain.Entities;
using EvalTask.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EvalTask.Swagger;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
            //     ,
            // x => x.MigrationsAssembly("EvalTask.Data")
 
            // services.AddIdentity<User, IdentityRole>()
            //     .AddEntityFrameworkStores<EvalTaskContext>();
            services.AddDefaultIdentity<User>(ConfigureIdentity)
                .AddEntityFrameworkStores<EvalTaskContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IdentityDbContext<User>, EvalTaskContext>();
            services.Do(ConfigureAuthentication);
            services.AddMediatR(typeof(Startup));
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
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
    }
}