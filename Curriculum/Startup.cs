using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MakeCurriculum.Data;
using MakeCurriculum.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;

namespace MakeCurriculum
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
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnDB")));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Users/Login";
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<CurriculumService>();
            services.AddScoped<UserService>();
            services.AddScoped<LoginInformationService>();
            services.AddScoped<ObjectiveService>();
            services.AddScoped<AcademicService>();
            services.AddScoped<CoursesTypeService>();
            services.AddScoped<ProfessionalExpService>();
            services.AddScoped<LanguageService>();
            services.AddScoped<PersonalDataService>();
            services.AddScoped<ExtraActivityService>();
            services.AddScoped<ResumeService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var ptBR = new CultureInfo("pt-BR");
            var localOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ptBR),
                SupportedCultures = new List<CultureInfo> { ptBR },             // lista de idiomas suportados
                SupportedUICultures = new List<CultureInfo> { ptBR }
            };
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceProvider>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Context>();
                context.Database.EnsureCreated();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseRequestLocalization(localOptions);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();

            RotativaConfiguration.Setup(env);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Users}/{action=Register}/{id?}");
            });
        }
    }
}
