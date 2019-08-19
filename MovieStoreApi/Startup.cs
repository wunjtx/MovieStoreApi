using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieStore.Data;
using MovieStore.Data.RepositoryImplementations;
using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using MovieStore.Services.ServiceImplementations;
using MovieStore.Services.ServiceInterfaces;
using MovieStoreApi.Infrastructure;
using MovieStoreApi.Infrastructure.Automapper;
using MovieStoreApi.Infrastructure.Error;
using MovieStoreApi.Infrastructure.Filter;
using MovieStoreApi.Infrastructure.Log;
using Swashbuckle.AspNetCore.Swagger;

namespace MovieStoreApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            Configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        public IConfiguration Configuration { get; }
        private readonly IServiceProvider _serviceProvider;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<MovieStoreDbContext>(options=> 
            {
                options.UseSqlServer(Configuration.GetConnectionString("MovieStoreConnection"));
            });

            services.AddSingleton<ILoggerManager, LoggerManager>();
            
            services.AddMvc(options =>
            {
                //add to all controller and action
                //options.Filters.Add(new AddHeaderAttribute("GlobalAddHeader", "Result filter added to MvcOptions.Filters"));         // An instance
                options.Filters.Add(new LogConstantFilter("GlobalAddHeader", services));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MovieStore API", Version = "v1", Description = "MovieStore Api Docs" });
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
            mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["TokenSettings:PrivateKey"]))
                    };
                });
            
            //Add service filters. use servicefilter attribute but service filter can not pass parameter
            //services.AddScoped<AddHeaderResultServiceFilter>(); //register in service, the life cycle will be managed by service.

            services.AddScoped<IRatingDTO, RatingDTO>();

            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICrewRepository, CrewRepository>();
            services.AddScoped<ICastRepository, CastRepository>();

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICryptoService, CryptoService>();
            services.AddScoped<ICrewService, CrewService>();
            services.AddScoped<ICastService, CastService>();
            services.AddScoped<IAdminService, AdminService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler(logger); //extend UseExceptionHandler middleware
            //app.ConfigureCustomExceptionMiddleware(); //custom middleware

            app.UseCors(s=>s.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
