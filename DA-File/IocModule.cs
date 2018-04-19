using Ninject;
using Ninject.Modules;

using Home.BO;

namespace Home.DA
{
    public class IocModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMenuRepository>().To<MenuRepository>().InTransientScope()
                .WithConstructorArgument<string>(context => context.Kernel.Get<string>("DataDirectory"));
            Bind<IRecipeRepository>().To<RecipeRepository>().InTransientScope()
                .WithConstructorArgument<string>(contect => contect.Kernel.Get<string>("DataDirectory"));
            Bind<IShoppingListRepository>().To<ShoppingListRepository>().InTransientScope()
                .WithConstructorArgument<string>(context => context.Kernel.Get<string>("DataDirectory"));
        }
    }
}
