using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Home.BO;

namespace Home.Web.Controllers.api
{
    [Route("api/recipes")]
    public class RecipesApiController : Controller
    {
        private IRecipeRepository _Repository;

        public RecipesApiController(IRecipeRepository repository)
        {
            _Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _Repository.FetchList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {

            var result = _Repository.FetchEditor(id);
            if (result == null)
                return NotFound($"Recipe {id} not found.");
            return Ok(result);
        }

        [HttpGet("new")]
        public IActionResult GetNew()
        {
            var result = _Repository.Create();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id, [FromBody]byte[] concurrency)
        {
            var result = _Repository.Delete(id, concurrency);
            if (result.ConcurrencyViolation)
                return StatusCode(StatusCodes.Status409Conflict, result.Data);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromBody]RecipeEditor data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = _Repository.Save(data);
            if (result.ConcurrencyViolation)
                return StatusCode(StatusCodes.Status409Conflict, result.Data);
            return Ok(result.Data);
        }
    }
}
