using System;
using System.IO;

using Newtonsoft.Json;

using Home.BO;

namespace Home.DA
{
    public class MenuRepository : IMenuRepository
    {
        private string _FileSpec;

        private MenuRepository(string dataDirectory)
        {
            if (dataDirectory == null)
                throw new ArgumentNullException(nameof(dataDirectory));
            _FileSpec = Path.Combine(dataDirectory, "menu.json");
        }

        public MenuEditor Fetch()
        {
            if (!File.Exists(_FileSpec))
                return new MenuEditor();
            using (var stream = new FileStream(_FileSpec, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(stream))
                return JsonConvert.DeserializeObject<MenuEditor>(reader.ReadToEnd());
        }

        public ConcurrencyResult<MenuEditor> Save(MenuEditor data, bool removePreparedMeals = false)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            for (var i = 0; removePreparedMeals && i < data.Items.Count; ++i)
                if (data.Items[i].Prepared)
                    data.Items.RemoveAt(i--);
            using (var writer = new StreamWriter(_FileSpec))
            {
                writer.Write(JsonConvert.SerializeObject(data));
            }
            return new ConcurrencyResult<MenuEditor>(data);
        }
    }
}
