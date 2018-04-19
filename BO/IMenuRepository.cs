namespace Home.BO
{
    public interface IMenuRepository
    {
        MenuEditor Fetch();

        ConcurrencyResult<MenuEditor> Save(MenuEditor data, bool removePreparedMeals = false);
    }
}
