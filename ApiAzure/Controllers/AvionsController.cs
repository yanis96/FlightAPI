using ApiAzure.Data;
using ApiAzure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvionsController : ControllerBase
    {
        private readonly FlightDbContext _context;

        public AvionsController(FlightDbContext context)
        {
            _context = context;
        }

        //"api/Avions"
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avion>>> GetAvion([FromQuery] PaginationParams @params)
        {
            return await _context.Avions
                                 .Skip((@params.Page - 1) * @params.ItemsPerPage)
                                 .Take(@params.ItemsPerPage)
                                 .ToListAsync();
        }

        // "api/Avions/[numAvion]"
        [HttpGet("{numAvion}")]
        public async Task<ActionResult<Avion>> GetAvionByNumAvion(string numAvion)
        {
            var avion = await _context.Avions.Where(a => a.numAvion == numAvion).FirstOrDefaultAsync();
            if(avion == null)
            {
                return NotFound();
            }
            return avion;
        }

        // "api/Avions
        [HttpPost]
        public async Task<ActionResult<Avion>> CreateAvion(Avion avion)
        {
            _context.Avions.Add(avion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAvionByNumAvion), new { id = avion.ID }, avion);
        }

        [HttpDelete("{numAvion}")]
        public async Task<ActionResult<Avion>> DeleteAvion(string numAvion)
        {
            var avion = await _context.Avions.Where(a => a.numAvion == numAvion).FirstOrDefaultAsync();
            if (avion == null)
            {
                return NotFound();
            }
            _context.Avions.Remove(avion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }


}
