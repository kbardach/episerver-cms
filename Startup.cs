using EPiServer.Cms.Shell;
using EPiServer.Cms.Shell.UI.Configurations;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using kim_episerver.Business.Extensions;
using kim_episerver.Business.Services;
using kim_episerver.Business.Services.Interfaces;

namespace kim_episerver
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;

        public Startup(IWebHostEnvironment webHostingEnvironment)
        {
            _webHostingEnvironment = webHostingEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_webHostingEnvironment.IsDevelopment())
            {
                AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

                services.Configure<SchedulerOptions>(options => options.Enabled = false);
            }

            services.Configure<UploadOptions>(x =>
            {
                x.FileSizeLimit = 52428800; // Filstorleksbegränsning satt till 50 MB
            });

            services
                .AddCmsAspNetIdentity<ApplicationUser>()
                .AddCms()
                .AddNackademin()
                .AddAdminUserRegistration()
                .AddEmbeddedLocalization<Startup>();

            services.AddHttpClient<IMovieService, MovieService>();
            services.AddSingleton<IXmlSitemapService, XmlSitemapService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Custom 404 Handling
            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == 404)
                {
                    context.HttpContext.Request.Path = "/error";

                    await context.Next(context.HttpContext);
                }
            });

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapContent();
            });
        }
    }
}
