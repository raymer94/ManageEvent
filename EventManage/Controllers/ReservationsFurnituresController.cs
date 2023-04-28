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
    public class ReservationsFurnituresController : ControllerBase
    {
        private readonly IRepositoryService<ReservationsFurniture> _reservationsFurnituresService;

        public ReservationsFurnituresController(IRepositoryService<ReservationsFurniture> reservationsFurnituresService)
        {
            _reservationsFurnituresService = reservationsFurnituresService;
        }

        // GET: api/ReservationsFurnitures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationsFurniture>>> GetReservationsFurnitures()
        {
            var statuses = await _reservationsFurnituresService.GetAllAsync();
            return Ok(statuses);
        }

        // GET: api/ReservationsFurnitures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationsFurniture>> GetReservationsFurniture(int id)
        {
            var status = await _reservationsFurnituresService.GetByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        // PUT: api/ReservationsFurnitures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservationsFurniture(int id, ReservationsFurniture reservationsFurniture)
        {
            if (id != reservationsFurniture.Id)
            {
                return BadRequest();
            }

            var existingStatus = await _reservationsFurnituresService.GetByIdAsync(id);
            if (existingStatus == null)
            {
                return NotFound();
            }

            await _reservationsFurnituresService.UpdateAsync(reservationsFurniture);

            return NoContent();
        }

        // POST: api/ReservationsFurnitures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservationsFurniture>> PostReservationsFurniture(ReservationsFurniture reservationsFurniture)
        {
            await _reservationsFurnituresService.AddAsync(reservationsFurniture);
            return CreatedAtAction(nameof(GetReservationsFurniture), new { id = reservationsFurniture.Id }, reservationsFurniture);
        }

        // DELETE: api/ReservationsFurnitures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationsFurniture(int id)
        {
            await _reservationsFurnituresService.DeleteAsync(id);

            return NoContent();
        }
    }
}
