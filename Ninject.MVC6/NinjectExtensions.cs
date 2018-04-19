using System;
using System.Collections.Generic;
using System.Threading;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;

using Ninject.Infrastructure.Disposal;

namespace Ninject.MVC6
{
    public static class NinjectExtensions
    {
        private class Scope : DisposableObject { }
        private static readonly AsyncLocal<Scope> _ScopeProvider = new AsyncLocal<Scope>();

        public static IServiceCollection AddNinject(this IServiceCollection services, Action<IKernel> initializeNinjectKernel = null)
        {
            if (services == null) throw new ArgumentException(nameof(services));
            // The one and only kernel;
            Kernel = new StandardKernel();
            services.AddSingleton<IKernel>(Kernel);
            // Stuff for request scoping
            var httpContextAccessor = new HttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor>(httpContextAccessor);
            services.AddSingleton<IStartupFilter>(new NinjectRequestScopeConfiguration(() => _ScopeProvider.Value = new Scope()));
            // Activators
            services.AddSingleton<IControllerActivator>(new NinjectControllerActivator(Kernel));
            services.AddSingleton<IViewComponentActivator>(new NinjectViewComponentActivator(Kernel));
            // 
            if (initializeNinjectKernel != null)
                initializeNinjectKernel.Invoke(Kernel);
            return services;
        }

        public static IApplicationBuilder UseNinject(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentException(nameof(app));

            var kernel = app.ApplicationServices.GetService<IKernel>();
            if (kernel == null) throw new IndexOutOfRangeException(
                "Could not locate Ninject.IKernel. Did you forget to call AddNinject in the ConfigureServices method?");

            foreach (var controllerType in app.GetControllerTypes())
                kernel.Bind(controllerType).ToSelf().InScope(context => RequestScope);

            return app;
        }

        private static IEnumerable<Type> GetControllerTypes(this IApplicationBuilder builder)
        {
            var partManager = builder.ApplicationServices.GetRequiredService<ApplicationPartManager>();
            var feature = new ControllerFeature();
            partManager.PopulateFeature(feature);
            foreach (var controller in feature.Controllers)
                yield return controller.AsType();
            yield break;
        }

        public static IKernel Kernel
        { get; private set; }

        public static object RequestScope
        {
            get { return _ScopeProvider.Value; }
        }
    }
}
