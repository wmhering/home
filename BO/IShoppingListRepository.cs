namespace Home.BO
{
    public interface IShoppingListRepository
    {
        ShoppingListEditor Fetch();

        ConcurrencyResult<ShoppingListEditor> Save(ShoppingListEditor data, bool removePurchasedItems = false);
    }
}
