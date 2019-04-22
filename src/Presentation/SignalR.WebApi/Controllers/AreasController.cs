namespace SignalR.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SignalR.Entities;
    using SignalR.Services;

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AreasController : ControllerBase
    {

        protected readonly IAreaOperations Helper;

        public AreasController(IAreaOperations helper)
        {
            this.Helper = helper;
        }

        // GET: api/Areas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Helper.GetBy(new QueryParameters<Area>());
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        //// GET: api/Areas/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Areas
        [HttpPost]
        public Area Post([FromBody] Area area)
        {
            return this.Helper.Create(area);
        }

        // PUT: api/Areas/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
