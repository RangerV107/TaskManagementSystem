using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain;
using TaskManager.Infrastructure;
using TaskManager.API.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InDocumentsController : ControllerBase
    {
        private readonly InDocumentsRepository _repository;

        public InDocumentsController(Context context)
        {
            _repository = new InDocumentsRepository(context);
        }


        // GET: api/InDocuments
        [HttpGet]
        public async Task<ActionResult<List<InDocumentDTO>>> GetInDocuments()
        {
            var inDocuments = await _repository.GetAllAsync();
            List<InDocumentDTO> inDocumentDTOs = new List<InDocumentDTO>();
            foreach (var task in inDocuments)
            {
                inDocumentDTOs.Add(Converters.ToInDocumentDTO(task));
            }
            return inDocumentDTOs;
        }

        // GET: api/InDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InDocumentDTO>> GetInDocument(Guid id)
        {
            var inDocument = await _repository.GetAsync(id);

            if (inDocument == null)
            {
                return NotFound();
            }

            return Converters.ToInDocumentDTO(inDocument);
        }

        // PUT: api/InDocuments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInDocument(Guid id, InDocumentDTO inDocumentsDTO)
        {
            if (id != inDocumentsDTO.Id)
            {
                return BadRequest();
            }

            bool ok = await _repository.UpdateAsync(Converters.ToInDocument(inDocumentsDTO));

            if (ok)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/InDocuments
        [HttpPost]
        public async Task<ActionResult<InDocument>> PostInDocument(InDocument inDocument)
        {
            await _repository.AddAsync(inDocument);
            return Ok();
        }

        // DELETE: api/InDocument/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInDocument(Guid id)
        {
            var inDocument = await _repository.GetAsync(id);
            if (inDocument == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(inDocument.Id);

            return Ok();
        }

    }

}
