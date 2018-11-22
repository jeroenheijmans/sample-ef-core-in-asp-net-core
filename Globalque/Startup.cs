using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Globalque
{
    public class Startup
    {
        private const string ApiName = "Globalque";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = Configuration.GetConnectionString("GlobalqueDatabase");
            services.AddDbContext<PeopleDbContext>(options => options.UseSqlServer(connectionString));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = ApiName, Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiName); c.RoutePrefix = ""; });

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
