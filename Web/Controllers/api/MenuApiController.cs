using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Home.BO;

namespace Home.Web.Controllers.api
{
    [Route("api/menu")]
    public class MenuApiController : Controller
    {
        private IMenuRepository _Repository;

        public MenuApiController(IMenuRepository repository)
        {
            _Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _Repository.Fetch();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]MenuEditor data, [FromQuery]bool removePreparedMeals = false)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = _Repository.Save(data, removePreparedMeals);
            if (result.ConcurrencyViolation)
                return StatusCode(StatusCodes.Status409Conflict, result.Data);
            return Ok(result.Data);
        }
    }
}