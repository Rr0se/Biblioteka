using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marta_M.Entities;
using Marta_M.Repository.AuthorRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Marta_M
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<DataBaseContext>(opt =>
            //    opt.UseInMemoryDatabase("EmployeeList"));
            services.AddMvc();

            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=DbBook;Trusted_Connection=True;";
            //var connectionString = @"Server=DESKTOP-18VF6FQ\SQLEXPRESS;Database=DbBook;Trusted_Connection=True;";
            services.AddDbContext<DataBaseContext>(o => o.UseSqlServer(connectionString));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API", Version = "v1" });
                c.DescribeAllEnumsAsStrings();
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });
            });

            //register repo
            //services.AddScoped<IProfileGeneratorServices, ProfileGeneratorServices>();
            //services.AddCors();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetPreflightMaxAge(TimeSpan.FromSeconds(2520))
                        .Build());
            });

            services.AddScoped<IAuthorsRepository, AuthorsRepository>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataBaseContext dataBaseContext)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Entities.Employee, Models.Profile>()
            //        .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
            //           $"{src.FirstName} {src.LastName} {src.Specialization} {src.YearsOfWork}"));

            //    cfg.CreateMap<InputModels.EmployeeInputModel, Entities.Employee>();
            //});

            //app.UseCors(builder =>
            //    builder.WithOrigins("http://localhost:19586/#/Book"));

            app.UseCors("CorsPolicy");
            app.UseMvc();




        }
    }
}
