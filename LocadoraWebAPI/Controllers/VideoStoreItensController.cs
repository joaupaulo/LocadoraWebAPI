using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocadoraWebAPI.Domain;
using LocadoraWebAPI.Domain.VideoStoreContext;

namespace LocadoraWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoStoreItensController : ControllerBase
    {
        private readonly VideoStoreDbContext _context;

        public VideoStoreItensController(VideoStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/VideoStoreItens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoStoreItens>>> GetVideoStoreItens()
        {
            return await _context.VideoStoreItens.ToListAsync();
        }

        // GET: api/VideoStoreItens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoStoreItens>> GetVideoStoreItens(int id)
        {
            var videoStoreItens = await _context.VideoStoreItens.FindAsync(id);

            if (videoStoreItens == null)
            {
                return NotFound();
            }

            return videoStoreItens;
        }

        // PUT: api/VideoStoreItens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoStoreItens(int id, VideoStoreItens videoStoreItens)
        {
            if (id != videoStoreItens.VideoStoreID)
            {
                return BadRequest();
            }

            _context.Entry(videoStoreItens).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoStoreItensExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VideoStoreItens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VideoStoreItens>> PostVideoStoreItens(VideoStoreItens videoStoreItens)
        {
            _context.VideoStoreItens.Add(videoStoreItens);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideoStoreItens", new { id = videoStoreItens.VideoStoreID }, videoStoreItens);
        }

        // DELETE: api/VideoStoreItens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoStoreItens(int id)
        {
            var videoStoreItens = await _context.VideoStoreItens.FindAsync(id);
            if (videoStoreItens == null)
            {
                return NotFound();
            }

            _context.VideoStoreItens.Remove(videoStoreItens);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoStoreItensExists(int id)
        {
            return _context.VideoStoreItens.Any(e => e.VideoStoreID == id);
        }
    }
}
