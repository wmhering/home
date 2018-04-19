using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Home.Web.Controllers
{
    [Route("menu")]
    public class MenuController : Controller
    {
 
        [HttpGet]
        // GET: /menu/
        public IActionResult Get()
        {
            return View();
        }
    }
}
