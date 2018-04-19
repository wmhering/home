using System;
using System.Collections.Generic;
using System.Text;

namespace Home.BO
{
    public interface IRecipeRepository
    {
        /// <summary>
        /// Creates a new <see cref="T:RecipeEditor"/> to be used to edit a new recipe.</summary>
        /// <returns>
        /// An empty <see cref="T:RecipeEditor"/> object that may be edited and saved.</returns>
        RecipeEditor Create();

        /// <summary>
        /// Deletes a recipe.</summary>
        /// <param name="key">
        /// The unique identifier of the recipe to be deleted.</param>
        /// <param name="concurrency">
        /// A value that identifies the version of the recipe used to ensure that another user has not changed the recipe since the current user fetched it.</param>
        ConcurrencyResult<RecipeEditor> Delete(int key, byte[] concurrency);

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        RecipeEditor FetchEditor(int key);

        IEnumerable<RecipeSummary> FetchList();

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ConcurrencyResult<RecipeEditor> Save(RecipeEditor data);
    }
}
