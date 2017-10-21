using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TemplateDotnetCoreApi.Models;
using TemplateDotnetCoreApi.Repository;

namespace TemplateDotnetCoreApi.Controllers
{
    [Route("api/[controller]")]
    public class ValueController : Controller
    {
        public IValueRepository ValueRepo { get; set; }
        
        public ValueController(IValueRepository _repo)
        {
            ValueRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<Value> GetAll()
        {
            return ValueRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetValue")]
        public IActionResult GetById(long id)
        {
            var item = ValueRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Value item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            ValueRepo.Add(item);
            return CreatedAtRoute("GetValue", new { Controller = "Value", id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Value item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = ValueRepo.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            ValueRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ValueRepo.Remove(id);
        }
    }
}
