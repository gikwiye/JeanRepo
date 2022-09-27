using Azure.Storage.Blobs;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyCineBel.API.DAL;
using MyCineBel.API.Handler;
using MyCineBel.API.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyCineBel.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(x => new BlobServiceClient(Configuration.GetValue<string>("AzureBlobStorageConnectionString")));

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.AddDbContext<ProjetMyCinebelContext>(options => options.UseSqlServer
           (Configuration.GetConnectionString("ProjetMyCinebelContext")));

            var domain = $"https://{Configuration["Auth0:Domain"]}/";

            services.AddAuthentication(options =>

            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = Configuration["Auth0:Audience"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier,
                   
                };
            });

            // cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                  builder => builder
                  .AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod());
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:comptes", policy => policy.Requirements.Add(new HasScopeRequirement("read:comptes", domain)));
            
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IActeurService, ActeurService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IRealisateurService, RealisateurService>();
            services.AddScoped<ICinemaService, CinemaService>();
            services.AddScoped<ISalleService, SalleService>();
            services.AddScoped<IDetailFilmService, DetailFilmService>();
            services.AddScoped<ISeanceService, SeanceService>();
            services.AddScoped<ITarifService, TarifService>();
            services.AddScoped<ITarifSeanceService, TarifSeanceService>();
            services.AddScoped<ICompteService, CompteService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<INewsService, NewsService>();


            services.AddSingleton<IBlobService, BlobService>();

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                {
                    Version = "v1",
                    Title = "MyCineBel.API",
                    Description= "An Api for booking ticket for cinema",
                    Contact= new OpenApiContact
                    {
                        Name ="Musoni Jean",
                        Email="j.musonimurasa@students.ephec.be"
                    }
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCineBel.API v1"));
            }

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

         

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseSwaggerUI(c =>
            {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCineBel.API v1");
                c.RoutePrefix = string.Empty;
            } );


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
