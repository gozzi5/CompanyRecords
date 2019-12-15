using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Services;

namespace CompanyRecords
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration) {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
           services.AddDbContext<CompanyRecordsDBContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("CompanyRecordContext")));

            //company services
            services.AddScoped<ICompanyService, CompanyService>();



            // Add Authentication with JWT Tokens
            services.AddAuthentication(opts =>
            {
                opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(cfg =>
             {
                 cfg.RequireHttpsMetadata = false;
                 cfg.SaveToken = true;
                 cfg.TokenValidationParameters = new TokenValidationParameters()
                 {
                     // standard configuration
                     ValidIssuer = Configuration["Auth:Jwt:Issuer"],
                     ValidAudience = Configuration["Auth:Jwt:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(
                     Encoding.UTF8.GetBytes(Configuration["Auth:Jwt:Key"])),
                     ClockSkew = TimeSpan.Zero,

                     // security switches
                     RequireExpirationTime = true,
                     ValidateIssuer = true,
                     ValidateIssuerSigningKey = true,
                     ValidateAudience = true
                 };
             });

            services.AddCors(options =>
            {
                
                options.AddPolicy(MyAllowSpecificOrigins,
                   

            builder =>
                {
                    builder.WithOrigins("http://localhost:4200");
                    builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
                });
            });

            services.AddAuthorization();

            services.AddControllers().AddNewtonsoftJson(); 

            services.AddMvc();

            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);

            services.AddResponseCompression();

      

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseCors(MyAllowSpecificOrigins);
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CompanyRecordsDBContext>();
                context.Database.Migrate();
              
            }



            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.Use(async (context, next) =>
            {

                await next();

                if (context.Response.StatusCode == 404
                && !Path.HasExtension(context.Request.Path.Value))
                {

                    context.Request.Path = "/index.html";
                    await next();
                }
               

            });

            app.UseStaticFiles();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
