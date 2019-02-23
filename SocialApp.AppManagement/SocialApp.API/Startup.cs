using SocialApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SocialApp.Core
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
			services.AddCors();
			services.AddMvc();
			services.AddSingleton<IConfiguration>(Configuration);
			IConfiguration _configuration = Configuration;
			var connection = _configuration["connectionString"];
			services.AddDbContext<GoingOutContext>(options => options.UseSqlServer(connection));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
				app.UseHttpStatusCodeExceptionMiddleware();
			}
			else
			{
				app.UseHttpStatusCodeExceptionMiddleware();
			}

			app.UseStaticFiles();
			app.UseCors(builder =>
				builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
			);
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action=Index}/{id?}");

			});
		}
	}
}
