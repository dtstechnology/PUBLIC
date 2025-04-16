
using Autofac.Core;
using AutoMapper;
using Data.Access.Layer;
using Data.Access.Layer.DataContext;
using DTS.Core;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using DTS.Logic.Layer.AutoMappers;
using DTS.Logic.Layer.DataIO;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Text.Json;

namespace DTS.Ear
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
            services.AddDbContext<DatabaseContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("MySQL"))
            );
            services.AddTransient<IUnitofWork, UnitofWork>();
            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
            services.AddHttpContextAccessor();

            services.AddControllersWithViews();
            //services.AddCustomConfiguredAutoMapper(); 
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/SignIn";
                    options.AccessDeniedPath = "/Home/AccessDenied";
                    options.ExpireTimeSpan = TimeSpan.FromHours(2);
                    options.SlidingExpiration = true;
                    options.Events = new CookieAuthenticationEvents()
                    {
                        OnSigningIn = async context =>
                        {
                            await Task.CompletedTask;
                        },
                        OnSignedIn = async context =>
                        {
                            await Task.CompletedTask;
                        },
                        OnValidatePrincipal = async context =>
                        {
                            await Task.CompletedTask;
                        }
                    };

                });

            services.AddLocalization();



            //services.AddSignalR(); //SignalR
            services.AddDataProtection();
            services.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement, UnicodeRanges.LatinExtendedA }));
            services.AddMvc();

            services.AddControllersWithViews().AddJsonOptions(opts => { 
                opts.JsonSerializerOptions.PropertyNamingPolicy = null;
                opts.JsonSerializerOptions.Converters.Add(new DecimalConverter());
            });



            var defaultCulture = new CultureInfo("en-US");
            defaultCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            defaultCulture.NumberFormat.CurrencyGroupSeparator = ",";
            defaultCulture.NumberFormat.CurrencyDecimalDigits = 2;
            defaultCulture.NumberFormat.CurrencySymbol = "";

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRequestLocalization();

            //var supportedCultures = new[]{
            //    new CultureInfo("en-US"),
            //};
            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture("en-US"),
            //    SupportedCultures = supportedCultures,
            //    FallBackToParentCultures = false

            //});
            //CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            //CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ",";
            //CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ".";
            //CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits = 2;
            //CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol = "";



            //app.UseMiddleware<ExceptionHandlerMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseCookiePolicy();



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHub<OnlineUsersHub>("/onlineUsersHub"); //SignalR
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Dashboard}/{id?}");
            });
        }
    }


   
}
