using Microsoft.AspNetCore.Mvc;

namespace Home.Web.Controllers
{
    [Route("recipes")]
    public class RecipesController : Controller
    {
        [HttpGet(Name = nameof(RecipesController))]
        // GET: /recipes/
        public IActionResult Get()
        {
            return View("List");
        }

        [HttpGet("new")]
        [HttpGet("{id:int}")]
        // GET: /recipes/1
        public IActionResult Get(int id = 0)
        {
            return View("Edit");
        }

        [HttpPost("new")]
        [HttpPost("{id:int}")]
        // POST: /recipes/1
        public IActionResult Post(int id)
        {
            return View("Edit");
        }
    }
}