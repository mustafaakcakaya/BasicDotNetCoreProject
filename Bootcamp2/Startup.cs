using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootcamp2.Context;
using Bootcamp2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bootcamp2
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
            #region notlar
            //services.AddControllersWithViews().AddRazorRuntimeCompilation(); 
            #endregion
            services.AddRazorPages().AddRazorRuntimeCompilation().AddMvcOptions(options=> {
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "Bu alan boþ býrakýlamaz.");
            });
            services.AddControllersWithViews();
            services.AddScoped <ScopedService>();
            services.AddTransient <TransientClass>();
            services.AddSingleton<UserContext>();
            services.AddTransient<UserService>();
            services.AddScoped<MessageService>();
            services.AddSingleton<BookContext>();
            services.AddTransient<BookService>();
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
                    pattern: "{controller=User}/{action=Index}/{id?}");
            });
        }
    }
}
