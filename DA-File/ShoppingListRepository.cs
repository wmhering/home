using System;
using System.IO;

using Newtonsoft.Json;

using Home.BO;

namespace Home.DA
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private string _FileSpec;

        public ShoppingListRepository(string dataDirectory)
        {
            if (dataDirectory == null)
                throw new ArgumentNullException(nameof(dataDirectory));
            _FileSpec = Path.Combine(dataDirectory, "shopping_list.json");
        }

        public ShoppingListEditor Fetch()
        {
            if (!File.Exists(_FileSpec))
                return new ShoppingListEditor();
            using (var reader = new StreamReader(_FileSpec))
            {
                return JsonConvert.DeserializeObject<ShoppingListEditor>(reader.ReadToEnd());
            }
        }

        public ConcurrencyResult<ShoppingListEditor> Save(ShoppingListEditor data, bool removePurchasedItems = false)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            for (var i = 0; removePurchasedItems && i < data.Items.Count; ++i)
                if (data.Items[i].Purchased)
                    data.Items.RemoveAt(i--);            
            using (var writer = new StreamWriter(_FileSpec))
            {
                writer.Write(JsonConvert.SerializeObject(data));
            }
            return new ConcurrencyResult<ShoppingListEditor>(data);
        }
    }
}
