using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR.Entities;
using SignalR.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        protected readonly IRepository<Product> repository;

        public ValuesController(IRepository<Product> repo)
        {
            repository = repo;
            repository.Add(new Product
            {
                ProductName = "Mouse Razer",
                UnitPrice = 17000,
                UnitsInStock = 20
            });
            repository.SaveChanges();
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var result = repository.GetAll().Result;
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var result = repository.GetById(id).Result;
            return result;
        }

        // POST api/values
        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            var result = repository.Add(product).Result;
            repository.SaveChanges();
            return result;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var result = repository.Update(product);
            repository.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete(id);
            repository.SaveChanges();
        }
    }
}
