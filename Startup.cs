using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace aa_time_1 {

    public class Startup {
        public IConfiguration Configuration { get; }
        

		public Startup(IConfiguration configuration) {
            Configuration = configuration;
        } // construtor Startup


        // This method gets called by the runtime. 
		// Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();
        } // ConfigureServices


        // This method gets called by the runtime. 
		// Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. 
				// You may want to change this for production 
				// scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            } // if-else

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(
				endpoints => {
                	endpoints.MapRazorPages();
            	}
			);
        } // Configure

    } // class Startup

} // namespace aa_time_1
