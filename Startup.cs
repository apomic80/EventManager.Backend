using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.Business.Domain;
using EventManager.Data;
using EventManager.Infrastructure.Data;
using EventManager.Infrastructure.Data.Impl;
using EventManager.Models.Application;
using EventManager.Models.Application.Impl;
using EventManager.Models.Dtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace event_manager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Mapper.Initialize(cfg => {
                cfg.CreateMap<EventDto, Event>().ReverseMap();
                cfg.CreateMap<SpeakerDto, Speaker>().ReverseMap();
                cfg.CreateMap<AgendaItemDto, AgendaItem>().ReverseMap();
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();

            services.AddDbContext<EventManagerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configure project dependencies
            services.AddTransient<DbContext, EventManagerDbContext>();
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));
            services.AddTransient(typeof(IModelReader<>), typeof(EFModelReader<>));
            services.AddTransient<IEventsApplication, EventsApplication>();
            services.AddTransient<ISpeakersApplication, SpeakersApplication>();
            services.AddTransient<IAgendaApplication, AgendaApplication>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseErrorPage();
            app.UseDeveloperExceptionPage();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
