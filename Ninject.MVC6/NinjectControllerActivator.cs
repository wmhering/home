using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Ninject.MVC6
{
    internal class NinjectControllerActivator : IControllerActivator
    {
        private IKernel _Kernel;

        internal NinjectControllerActivator(IKernel kernel)
        {
            _Kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
        }

        public object Create(ControllerContext context)
        {
            var type = context.ActionDescriptor.ControllerTypeInfo.AsType();
            return _Kernel.Get(type);
        }

        public void Release(ControllerContext context, object controller)
        { }
    }
}
