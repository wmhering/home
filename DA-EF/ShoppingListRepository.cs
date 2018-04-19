using System.Linq;

using Home.BO;

namespace Home.DA
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private HomeContext _Context;

        public ShoppingListRepository(HomeContext context)
        {
            _Context = context;
        }

        public ShoppingListEditor Fetch()
        {            
            if (_Context.ShoppingLists.Count() == 0)
                return new ShoppingListEditor();
            var result = _Context.ShoppingLists.Select(d => new ShoppingListEditor()).First();
            result.Items = _Context.ShoppingLists.First().Items.Select(d => new ShoppingListEditor.Item { }).ToList();
            return result;
        }

        public ConcurrencyResult<ShoppingListEditor> Save(ShoppingListEditor data, bool removePurchasedItems = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
