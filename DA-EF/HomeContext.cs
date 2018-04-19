using Microsoft.EntityFrameworkCore;

using Home.DA.Data;

namespace Home.DA
{
    public class HomeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseSqlServer("Data Source=(local);Initial Catalog=Home;Integrated Security=SSPI");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Menu> Menus { get; set; }
 
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeSection> RecipeSections { get; set; }

        public DbSet<RecipeStep> RecipeSteps { get; set; }

        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }

        public DbSet<ShoppingList> ShoppingLists { get; set; }
    }
}
