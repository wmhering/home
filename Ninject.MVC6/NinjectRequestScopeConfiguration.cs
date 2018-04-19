using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Ninject.MVC6
{
    internal class NinjectRequestScopeConfiguration : IStartupFilter
    {
        private readonly Func<IDisposable> _ScopeProvider;

        public NinjectRequestScopeConfiguration(Func<IDisposable> scopeProvider)
        {
            _ScopeProvider = scopeProvider ?? throw new ArgumentNullException(nameof(scopeProvider)); ;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                ConfigureRequestScope(builder);
                next(builder);
            };
        }

        private void ConfigureRequestScope(IApplicationBuilder builder)
        {
            builder.Use(async (ContextBoundObject, next) =>
            {
                using (var scope = _ScopeProvider())
                {
                    await next();
                }
            });
        }
    }
}
