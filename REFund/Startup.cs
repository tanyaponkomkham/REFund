using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using REFund.Data;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace REFund
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
			services.Configure<CookiePolicyOptions>(options =>
			{

				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;

			});


			services.AddControllersWithViews();

			services.AddDbContext<CoreContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("iREFundConnection"), builder =>
				{
					builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
				}));

			services.AddMvc();

			//services.AddAuthentication(IISDefaults.AuthenticationScheme);

			//services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
			//{
			//	options.AccessDeniedPath = "/Auth/Login";
			//});

			//services.ConfigureApplicationCookie(options => options.LoginPath = "/Auth/Login");
			////services.AddHttpContextAccessor();

			//services.AddSession(options =>
			//{
			//	options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
			//});

			//var connection = Configuration.GetConnectionString("iREFundConnection");
			//services.AddDbContextPool<CoreContext>(options => options.UseSqlServer(connection));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=AllRequest}");
			});
		}
	}
}
