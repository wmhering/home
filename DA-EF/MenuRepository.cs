using Home.BO;

namespace Home.DA
{
    public class MenuRepository : IMenuRepository
    {
        public MenuEditor Fetch()
        {
            throw new System.NotImplementedException();
        }

        public ConcurrencyResult<MenuEditor> Save(MenuEditor data, bool removePreparedMeals = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
