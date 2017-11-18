using Kowalsky.Controllers.Sanitizers;
using Kowalsky.Services;
using Kowalsky.Services.Email;
using Kowalsky.Services.Sentry;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kowalsky
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.Configure<SentryOptions>(Configuration.GetSection("Sentry"));
            services.AddScoped<IErrorReporter, SentryErrorReporter>();

            services.AddTransient<IHomeSanitizer, HomeSanitizer>();
            services.AddTransient<IEmailTemplateService, EmailTemplateService>();

            services.Configure<MailOptions>(Configuration.GetSection("Mail"));
            services.AddTransient<IEmailSenderService, EmailSenderService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<SentryMiddleware>();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
