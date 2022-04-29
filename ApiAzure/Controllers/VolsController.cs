using ApiAzure.Data;
using ApiAzure.Models;
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
    public class VolsController : ControllerBase
    {
        private readonly FlightDbContext _context;

        public VolsController(FlightDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols([FromQuery] PaginationParams @params)
        {
            return await _context.Vols
                                 .Skip((@params.Page - 1) * @params.ItemsPerPage)
                                 .Take(@params.ItemsPerPage)
                                 .ToListAsync();
        }

        [HttpGet("{numVol}")]
        public async Task<ActionResult<Vol>> GetVolByNumVol(string numVol)
        {
            var vol = await _context.Vols.Where(c => c.numVol == numVol).FirstOrDefaultAsync();
            if(vol == null)
            {
                return NotFound();
            }
            return vol;
        }

        [HttpPost]
        public async Task<ActionResult<Vol>> CreateVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVolByNumVol), new { id = vol.ID }, vol);
        }

        [HttpDelete("{numVol}")]
        public async Task<ActionResult<Vol>> DeleteAvion(string numVol)
        {
            var vol = await _context.Vols.Where(v => v.numVol == numVol).FirstOrDefaultAsync();
            if(vol == null)
            {
                return NotFound();
            }
            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
