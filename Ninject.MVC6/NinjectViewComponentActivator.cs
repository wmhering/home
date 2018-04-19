using System;

using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Ninject.MVC6
{
    internal class NinjectViewComponentActivator : IViewComponentActivator
    {
        private IKernel _Kernel;

        internal NinjectViewComponentActivator(IKernel kernel)
        {
            _Kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
        }

        public object Create(ViewComponentContext context)
        {
            var type = context.ViewComponentDescriptor.TypeInfo.AsType();
            return _Kernel.Get(type);
        }

        public void Release(ViewComponentContext context, object viewComponent)
        { }
    }
}
