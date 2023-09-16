using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapinet.Controllers
{
    [ApiController]
    [Route("api")]
    public class FruitsController : ControllerBase
    {
        private readonly IFruitService _service;

        public FruitsController(IFruitService service){
            _service = service;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult<List<Fruit>>> GetList(){
            return Ok(await _service.GetList());
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<ActionResult<Fruit>> GetFruitById(int id){
            var fruit = await _service.GetFruitById(id);
            if(fruit == null){
                return NotFound("Fruit not found.");
            }
            return Ok(fruit);
        }

        [HttpPost]
        [Route("[controller]")]
        public async Task<ActionResult<List<Fruit>>> AddFruit(Fruit fruit){
            return Ok(await _service.AddFruit(fruit));
        }

        [HttpPut]
        [Route("[controller]/{id}")]
        public async Task<ActionResult<List<Fruit>>> UpdateFruit(Fruit requestFruit, int id){
            if(requestFruit.Id != id){
                return NotFound("Different fruit id at path and request body.");
            } 
            return Ok(await _service.UpdateFruit(requestFruit, id));
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public async Task<ActionResult<List<Fruit>>> DeleteFruit(int id){
            var fruit = await _service.GetFruitById(id);
            if(fruit == null){
                return NotFound("Fruit not found.");
            }
            return Ok(await _service.DeleteFruit(fruit));
        }      
    }
}