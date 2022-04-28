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
    public class HistoriesController : ControllerBase
    {
        private readonly FlightDbContext _context;

        public HistoriesController(FlightDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<History>>> GetHistories()
        {
            return await _context.Histories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<History>> GetHistoryById(int id)
        {
            var history = await _context.Histories.Where(c => c.ID == id).FirstOrDefaultAsync();
            if (history == null)
            {
                return NotFound();
            }
            return history;
        }

        [HttpPost]
        public async Task<ActionResult<History>> CreateVol(History history)
        {
            _context.Histories.Add(history);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHistoryById), new { id = history.ID }, history);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<History>> DeleteHistory(int id)
        {
            var history = await _context.Histories.Where(v => v.ID == id).FirstOrDefaultAsync();
            if (history == null)
            {
                return NotFound();
            }
            _context.Histories.Remove(history);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
