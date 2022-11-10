using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using penca.lb.data.Context;
using penca.lb.data.Repository.Interfaces;
using penca.lb.data.Services.Implementations;
using penca.lb.data.Services.Interfaces;

namespace penca.lb.api
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
            services.AddControllers();
            SetupDatabase(services);
            // inject dependecies
            services.AddTransient<ICompetitionService, CompetitionService>();
            services.AddTransient<ICompetitionRepository, CompetitionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseMvc();
        }

        public virtual void SetupDatabase(IServiceCollection services)
        {
            services.AddDbContext<PencaContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection"));
            });
        }

    }
}

