using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManage.Models;
using EventManage.Models.Services.IServices;
using EventManage.Models.Services.Services;

namespace EventManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnituresController : ControllerBase
    {
        private readonly IRepositoryService<Furniture> _furnitureService;

        public FurnituresController(IRepositoryService<Furniture> furnitureService)
        {
            _furnitureService = furnitureService;
        }

        // GET: api/Furnitures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Furniture>>> GetFurnitures()
        {
            var statuses = await _furnitureService.GetAllAsync();
            return Ok(statuses);
        }

        // GET: api/Furnitures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Furniture>> GetFurniture(int id)
        {
            var status = await _furnitureService.GetByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        // PUT: api/Furnitures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFurniture(int id, Furniture furniture)
        {
            if (id != furniture.Id)
            {
                return BadRequest();
            }

            var existingStatus = await _furnitureService.GetByIdAsync(id);
            if (existingStatus == null)
            {
                return NotFound();
            }

            await _furnitureService.UpdateAsync(furniture);

            return NoContent();
        }

        // POST: api/Furnitures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Furniture>> PostFurniture(Furniture furniture)
        {
            await _furnitureService.AddAsync(furniture);
            return CreatedAtAction(nameof(GetFurniture), new { id = furniture.Id }, furniture);
        }

        // DELETE: api/Furnitures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFurniture(int id)
        {
            await _furnitureService.DeleteAsync(id);

            return NoContent();
        }
    }
}
