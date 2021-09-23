using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain;
using TaskManager.Infrastructure;
using TaskManager.API.DTO;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace TaskManager.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductionTasksController : ControllerBase
    {
        private readonly ProductionTasksRepository _repository;

        public ProductionTasksController(Context context)
        {
            _repository = new ProductionTasksRepository(context);
        }



        // GET: api/ProductionTasks
        [HttpGet]
        public async Task<ActionResult<List<ProductionTaskDTO>>> GetProductionTasks()
        {
            var productionTasks = await _repository.GetAllAsync();
            List<ProductionTaskDTO> productionTaskDTOs = new List<ProductionTaskDTO>();
            foreach (var task in productionTasks)
            {
                productionTaskDTOs.Add(Converters.ToProductionTaskDTO(task));
            }
            return productionTaskDTOs;
        }

        // GET: api/ProductionTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionTaskDTO>> GetProductionTask(Guid id)
        {
            var productionTask = await _repository.GetAsync(id);

            if (productionTask == null)
            {
                return NotFound();
            }

            return Converters.ToProductionTaskDTO(productionTask);
        }

        // PUT: api/ProductionTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductionTask(Guid id, ProductionTaskDTO productionTaskDTO)
        {
            if (id != productionTaskDTO.Id)
            {
                return BadRequest();
            }

            bool ok = await _repository.UpdateAsync(Converters.ToProductionTask(productionTaskDTO));

            if (ok)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/ProductionTasks
        [HttpPost]
        public async Task<ActionResult<ProductionTask>> PostProductionTask(ProductionTask productionTask)
        {
            await _repository.AddAsync(productionTask);
            return Ok();
        }

        // DELETE: api/ProductionTask/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionTask(Guid id)
        {
            var productionTask = await _repository.GetAsync(id);
            if (productionTask == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(productionTask.Id);

            return Ok();
        }

    }

}
