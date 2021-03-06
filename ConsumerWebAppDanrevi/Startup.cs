﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProxy.Contracts;
using ApiProxy;
using Models.Article;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Session;
using ConsumerWebAppDanrevi.Middleware;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConsumerWebAppDanrevi.Services;
using ConsumerWebAppDanrevi.Services.Contracts;

namespace ConsumerWebAppDanrevi
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
           // services.AddDistributedMemoryCache();
            services.AddMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            // Gør HttpContext tilgængelig i services
            services.AddHttpContextAccessor();

            services.AddTransient<ITokenAuth, SessionTokenAuth>();

            // API proxies
            services.AddTransient<IArticleApiProxy>(p => new ArticleRestProxy(Configuration.GetValue<string>("ApiEndpoints:Articles")));
            services.AddTransient<ICourseApiProxy>(p => new CourseRestProxy(Configuration.GetValue<string>("ApiEndpoints:Courses")));
            services.AddTransient<IAuthApiProxy>(p => new AuthRestProxy(Configuration.GetValue<string>("ApiEndpoints:Auth")));
            services.AddTransient<ITagApiProxy>(p => new TagRestProxy(Configuration.GetValue<string>("ApiEndpoints:Tags")));
            services.AddTransient<IDeadlinesApiProxy>(p => new DeadlineRestProxy(Configuration.GetValue<string>("ApiEndpoints:Deadlines")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseMiddleware<TokenAuthMiddleware>();
            app.UseCookiePolicy();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
