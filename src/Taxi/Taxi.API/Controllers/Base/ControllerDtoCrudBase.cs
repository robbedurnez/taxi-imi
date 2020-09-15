using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxi.Domain.DTO.Base;
using Taxi.Domain.Interfaces;

namespace Taxi.API.Controllers.Base
{
    public class ControllerDtoCrudBase<Dto, Mr> : ControllerBase
        where Dto : DtoBase where Mr : IMappingRepository<Dto>
    {
        protected Mr _mappingRepository;
        
        public ControllerDtoCrudBase(Mr mr)
        {
            _mappingRepository = mr;
        }
        
        // GET: api/T
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(await _mappingRepository.ListAll());
        }
        
        // GET: api/T/2
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(string id)
        {
            Dto d = await _mappingRepository.GetById(id);
            
            if (d == null)
                return NotFound($"Entity with id {id} was not found!");
            
            return Ok(d);
        }
        
        // PUT: api/T/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] Dto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (id != dto.Id.ToString())
                return BadRequest($"No matching ID's");
            
            var d = await _mappingRepository.Update(dto);
            
            if (d == null)
                return NotFound($"Entity with {id} was not found!");
            
            return Ok(d);
        }
        
        // POST: api/T
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Dto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var d = await _mappingRepository.Add(dto);
            
            if (d == null)
                return NotFound($"Adding new entity failed!");
            
            return CreatedAtAction("Get", new { id = d.Id }, d);
        }

        // DELETE: api/T/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var dto = await _mappingRepository.Delete(id);
            
            if (dto == null)
                return NotFound($"Entity with id {id} was not found!");
            
            return Ok(dto);
        }
    }
}