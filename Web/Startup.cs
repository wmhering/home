using System.IO;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Ninject;
using Ninject.MVC6;
using Microsoft.AspNetCore.Http;

namespace Home.Web
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
            services.AddMvc();
            services.AddNinject(InitializeNinject);
        }

        private void InitializeNinject(IKernel kernel)
        {
            var dataDirctory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data");
            kernel.Bind<string>().ToConstant(dataDirctory).Named("DataDirectory");
            var pattern = Path.Combine(Directory.GetCurrentDirectory(), "modules", "*.dll");
            kernel.Load(pattern);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app
                .UseWhen(context => !context.Request.Path.StartsWithSegments(new PathString("/api")),
                    branch =>
                    {
                        if (env.IsDevelopment())
                        {
                            branch.UseDeveloperExceptionPage();
                            branch.UseBrowserLink();
                        }
                        else
                        {
                            app.UseExceptionHandler("/Home/Error");
                        }
                    })
                .UseStaticFiles()
                .UseNinject()
                .UseMvc();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
