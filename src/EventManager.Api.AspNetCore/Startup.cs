namespace EventManager.Api.AspNetCore
{
    using AutoMapper;
    using Business.Data.EF;
    using Business.Domain;
    using Infrastructure.Data;
    using Infrastructure.Data.Impl;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Models.Application;
    using Models.Application.Impl;
    using Models.Dtos;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Mapper.Initialize(cfg => {
                cfg.CreateMap<EventDto, Event>().ReverseMap();
                cfg.CreateMap<SpeakerDto, Speaker>().ReverseMap();
                cfg.CreateMap<AgendaItemDto, AgendaItem>().ReverseMap();
            });
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}

            app.UseCors(builder => builder.AllowAnyOrigin());

            app.UseMvc();
        }
    }
}
