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
    public class TaskTypesController : ControllerBase
    {
        private readonly TaskTypesRepository _repository;

        public TaskTypesController(Context context)
        {
            _repository = new TaskTypesRepository(context);
        }



        // GET: api/TaskTypes
        [HttpGet]
        public async Task<ActionResult<List<TaskTypeDTO>>> GetTaskTypes()
        {
            var taskTypes = await _repository.GetAllAsync();
            List<TaskTypeDTO> taskTypesDTOs = new List<TaskTypeDTO>();
            foreach (var type in taskTypes)
            {
                taskTypesDTOs.Add(Converters.ToTaskTypeDTO(type));
            }
            return taskTypesDTOs;
        }

        // GET: api/TaskTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskTypeDTO>> GetTaskType(Guid id)
        {
            var taskType = await _repository.GetAsync(id);

            if (taskType == null)
            {
                return NotFound();
            }

            return Converters.ToTaskTypeDTO(taskType);
        }

        // PUT: api/TaskTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskType(Guid id, TaskTypeDTO taskTypeDTO)
        {
            if (id != taskTypeDTO.Id)
            {
                return BadRequest();
            }

            bool ok = await _repository.UpdateAsync(Converters.ToTaskType(taskTypeDTO));

            if (ok)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/TaskTypes
        [HttpPost]
        public async Task<ActionResult<TaskType>> PostProductionTask(TaskType taskType)
        {
            await _repository.AddAsync(taskType);
            return Ok();
        }

        // DELETE: api/TaskTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskType(Guid id)
        {
            var taskType = await _repository.GetAsync(id);
            if (taskType == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(taskType.Id);
            return Ok();
        }
    }
}
