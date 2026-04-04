using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheVagabondTravel.Data;
using TheVagabondTravel.DTOs;
using TheVagabondTravel.Models;
using TheVagabondTravel.Repositories;
using TheVagabondTravel.Services;

namespace TheVagabondTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationService _service;

        public DestinationsController(IDestinationService service)
        {
            _service = service;
        }

        // GET: api/Destinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestination()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        // GET: api/Destinations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Destination>> GetDestination(int id)
        {
            var destination = await _service.GetByIdAsync(id);

            if (destination == null)
            {
                return NotFound();
            }

            return destination;
        }

        // PUT: api/Destinations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestination(int id, Destination destination)
        {
            if (id != destination.Id)
            {
                return BadRequest();
            }

            
            await _service.UpdateAsync(destination);
            //return NoContent();
            return NoContent();
        }

        // POST: api/Destinations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Destination>> PostDestination(CreateDestinationDto dto)
        {
            //_context.Destination.Add(destination);
            //await _context.SaveChangesAsync();
            var destination = new Destination
            {
                CityName = dto.CityName,
                Country = dto.Country,
                Description = dto.Description,
                Rating = dto.Rating,
                LastVisited = dto.LastVisited = DateTime.Now
            };

            await _service.AddAsync(destination);

            return CreatedAtAction("GetDestination", new { id = destination.Id }, destination);
        }

        // DELETE: api/Destinations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            //var destination = await _context.Destination.FindAsync(id);
            //if (destination == null)
            //{
            //    return NotFound();
            //}

            //_context.Destination.Remove(destination);
            //await _context.SaveChangesAsync();
            await _service.DeleteAsync(id);

            return NoContent();
        }

        //private bool DestinationExists(int id)
        //{
        //    return _service.Destination.Any(e => e.Id == id);
        //}
    }
}
