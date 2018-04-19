using Microsoft.AspNetCore.Mvc;

namespace Home.Web.Controllers
{
    [Route("shoppingList")]
    public class ShoppingListController : Controller
    {
        [HttpGet]
        // GET: /shoppingList/
        public IActionResult Get()
        {
            return View();
        }
    }
}