using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;
using ServiceNow.Domain.Services;
using ServiceNow.Logic.Client;
using ServiceNow.Logic.Service;
using System.Reflection;

namespace ServiceNow_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //    _configuration = configuration;
            var sNowURL = Configuration.GetSection("Credentials").GetSection("SNowURL").Value;
            var userName = Configuration.GetSection("Credentials").GetSection("Username").Value;
            var password = Configuration.GetSection("Credentials").GetSection("Password").Value;
            var instance = Configuration.GetSection("Credentials").GetSection("MyInstance").Value;
            

            services.AddScoped<IServiceNowClient>(x => { return new TableAPIClient(sNowURL, userName, password); });
            services.AddScoped<IIncidentService, IncidentService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProblemService, ProblemService>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable the Swagger..
            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
            });

            app.UseMvc();
        }
    }
}
