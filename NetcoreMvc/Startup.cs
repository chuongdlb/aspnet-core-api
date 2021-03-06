﻿
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetcoreMvc.AppService;
using NetcoreMvc.EntityFrameworkCore;
using NetcoreMvc.EntityFrameworkCore.Entities;
using NetcoreMvc.EntityFrameworkCore.Repositories;

namespace NetcoreMvc
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; private set; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase());

            services.AddEntityFramework().AddEntityFrameworkSqlite().AddDbContext<ApplicationContext>();
            // services.AddDbContext<ApplicationContext>(options =>
            //   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            // Add framework services.
            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
            services.AddMvc().AddDataAnnotationsLocalization();


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICityInfoService, CityInfoService>();
            services.AddTransient<IPointOfInterestService, PointOfInterestService>();
            
            // Configure localization
            services.Configure<RequestLocalizationOptions>(
                opts =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-GB"),
                        new CultureInfo("en-US"),
                        new CultureInfo("en"),
                        new CultureInfo("fr-FR"),
                        new CultureInfo("fr"),
                    };

                    opts.DefaultRequestCulture = new RequestCulture("en-GB");
                    // Formatting numbers, dates, etc.
                    opts.SupportedCultures = supportedCultures;
                    // UI strings that we have localized.
                    opts.SupportedUICultures = supportedCultures;
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
           ApplicationContext dbContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            else
            {
                app.UseExceptionHandler();
            }

            dbContext.EnsureSeedDataForContext();
            
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<City, Dto.CityWithoutPointsOfInterestDto>();
                cfg.CreateMap<City, Dto.CityDto>();
                cfg.CreateMap<PointOfInterest, Dto.PointOfInterestDto>();
            });
            app.UseStatusCodePages();
            
            app.UseMvc();
        }
    }
}