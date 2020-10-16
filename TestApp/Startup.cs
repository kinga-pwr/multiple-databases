using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultipleDatabases.DAL;
using MultipleDatabases.DAL.ProviderContexts;
using System;

namespace TestApp
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
            services.AddControllers();

            switch (Configuration.GetValue<string>("DatabaseProvider"))
            {
                case "SqlServer":
                    services.AddDbContext<TestDbContext, SqlServerTestDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TestDatabaseSqlServer")));
                    break;
                case "Oracle":
                    services.AddDbContext<TestDbContext, OracleTestDbContext>(options => options.UseOracle(Configuration.GetConnectionString("TestDatabaseOracle")));
                    break;
                default:
                    throw new Exception("No valid database provider! Available options: SqlServer, Oracle.");
            } 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
