using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Home.BO;

namespace Home.DA
{
    public class RecipeRepository : IRecipeRepository
    {
        private HomeContext _Context;

        public RecipeRepository(HomeContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public RecipeEditor Create()
        {
            throw new System.NotImplementedException();
        }

        public ConcurrencyResult<RecipeEditor> Delete(int key, byte[] concurrency)
        {
            throw new System.NotImplementedException();
        }

        public RecipeEditor FetchEditor(int id)
        {
            var r = _Context.Recipes
                .Include(o => o.Ingredients)
                .Include(o => o.Steps)
                .Include(o => o.Sections.Select(s => s.Ingredients))
                .Include(o => o.Sections.Select(s => s.Steps))
                .FirstOrDefault(o => o.ID == id);
            if (r == null)
                return null;

            throw new System.NotImplementedException();
        }

        public IEnumerable<RecipeSummary> FetchList()
        {
            throw new System.NotImplementedException();
        }

        public ConcurrencyResult<RecipeEditor> Save(RecipeEditor data)
        {
            throw new System.NotImplementedException();
        }
    }
}
