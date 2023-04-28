using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManage.Models;
using EventManage.Models.Services.IServices;
using EventManage.Models.IRepositorry;
using EventManage.Models.Services.Services;

namespace EventManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IRepositoryService<Status> _statusService;

        public StatusController(IRepositoryService<Status> statusService)
        {
            _statusService = statusService;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        {
            var statuses = await _statusService.GetAllAsync();
            return Ok(statuses);
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatus(int id)
        {
            var status = await _statusService.GetByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        // PUT: api/Status/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, Status status)
        {
            if (id != status.Id)
            {
                return BadRequest();
            }

            var existingStatus = await _statusService.GetByIdAsync(id);
            if (existingStatus == null)
            {
                return NotFound();
            }

            await _statusService.UpdateAsync(status);

            return NoContent();
        }

        // POST: api/Status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Status>> PostStatus(Status status)
        {
            await _statusService.AddAsync(status);
            return CreatedAtAction(nameof(GetStatus), new { id = status.Id }, status);
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            await _statusService.DeleteAsync(id);

            return NoContent();
        }
    }
}
