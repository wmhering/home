using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using Home.BO;

namespace Home.DA
{
    public class RecipeRepository : IRecipeRepository
    {
        private string _FileSpec;

        public RecipeRepository(string dataDirectory)
        {
            if (dataDirectory == null)
                throw new ArgumentNullException(nameof(dataDirectory));
            _FileSpec = Path.Combine(dataDirectory, "recipes.json");
        }

        private List<RecipeEditor> LoadData()
        {
            if (!File.Exists(_FileSpec))
                return new List<RecipeEditor>();
            using (var stream = new FileStream(_FileSpec, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(stream))
                return JsonConvert.DeserializeObject<List<RecipeEditor>>(reader.ReadToEnd());
        }

        private void SaveData(List<RecipeEditor> data)
        {
            using (var stream = new FileStream(_FileSpec, FileMode.Truncate, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(stream))
                writer.Write(JsonConvert.SerializeObject(data));
        }

        public RecipeEditor Create()
        {
            return new RecipeEditor();
        }

        public ConcurrencyResult<RecipeEditor> Delete(int key, byte[] concurrency)
        {
            var list = LoadData().Where(o => o.Key.HasValue && o.Key != key).ToList();
            SaveData(list);
            return new ConcurrencyResult<RecipeEditor>(null);
        }

        public RecipeEditor FetchEditor(int key)
        {
            return LoadData().FirstOrDefault(o => o.Key == key);
        }

        public IEnumerable<RecipeSummary> FetchList()
        {
            throw new NotImplementedException();
        }

        public ConcurrencyResult<RecipeEditor> Save(RecipeEditor data)
        {
            // Get list of recipes replacing old data wit new data or inserting new data.
            var list = LoadData();
            var key = data.Key ?? 0;
            if (key > 0)
            {
                var oldRecipe = list.FirstOrDefault(o => o.Key.HasValue && o.Key == key);
                if (oldRecipe != null)
                    list.Remove(oldRecipe);
            }
            list.Add(data);
            // Make sure all recipes have a unique positive key;
            key = Math.Max(list.Max(o => o.Key ?? 0), 0);
            foreach (var item in list)
                if ((item.Key ?? 0) <= 0)
                    item.Key = ++key;
            // Save recipes and return potentiallu updated data.
            SaveData(list);
            return new ConcurrencyResult<RecipeEditor>(data);
        }
    }
}
