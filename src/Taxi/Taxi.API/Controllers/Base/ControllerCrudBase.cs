using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxi.Domain;
using Taxi.Domain.Interfaces;

namespace Taxi.API.Controllers.Base
{
    public class ControllerCrudBase<T, R> : ControllerBase where T : EntityBase where R : IRepository<T>
    {
        protected R _repository;

        public ControllerCrudBase(R r)
        {
            _repository = r;
        }
        
        // GET: api/T
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(await _repository.ListAll());
        }
        
        // GET: api/T/2
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(string id)
        {
            var e = await _repository.GetById(id);
            
            if (e == null)
                return NotFound($"Entity with {id} was not found!");
            
            return Ok(e);
        }
        
        // PUT: api/T/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            if (id != entity.Id.ToString())
                return BadRequest();
                
            var e = await _repository.Update(entity);
                
            if (e == null)
                return NotFound($"Entity with {id} was not found!");
            
            return Ok(e);
        }
        
        // POST: api/T
        [HttpPost]
        public async Task<IActionResult> PostPublisher([FromBody] T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var e = await _repository.Add(entity);
            
            if (e == null)
                return NotFound($"Adding new entity failed!");
            
            return CreatedAtAction("Get", new { id = entity.Id }, entity); }
        
        // DELETE: api/T/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _repository.Delete(id);
            
            if (entity == null)
                return NotFound($"Entity with {id} was not found!");

            return Ok(entity);
        }
    }
}