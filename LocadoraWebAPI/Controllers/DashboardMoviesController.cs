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
    public class DashboardMoviesController : ControllerBase
    {
        private readonly VideoStoreDbContext _context;

        public DashboardMoviesController(VideoStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/DashboardMovies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DashboardMovie>>> GetDashboardMovie()
        {
            return await _context.DashboardMovie.ToListAsync();
        }

        // GET: api/DashboardMovies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DashboardMovie>> GetDashboardMovie(int id)
        {
            var dashboardMovie = await _context.DashboardMovie.FindAsync(id);

            if (dashboardMovie == null)
            {
                return NotFound();
            }

            return dashboardMovie;
        }

        // PUT: api/DashboardMovies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDashboardMovie(int id, DashboardMovie dashboardMovie)
        {
            if (id != dashboardMovie.DashBoardMoviesId)
            {
                return BadRequest();
            }

            _context.Entry(dashboardMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DashboardMovieExists(id))
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

        // POST: api/DashboardMovies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DashboardMovie>> PostDashboardMovie(DashboardMovie dashboardMovie)
        {
            _context.DashboardMovie.Add(dashboardMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDashboardMovie", new { id = dashboardMovie.DashBoardMoviesId }, dashboardMovie);
        }

        // DELETE: api/DashboardMovies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDashboardMovie(int id)
        {
            var dashboardMovie = await _context.DashboardMovie.FindAsync(id);
            if (dashboardMovie == null)
            {
                return NotFound();
            }

            _context.DashboardMovie.Remove(dashboardMovie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DashboardMovieExists(int id)
        {
            return _context.DashboardMovie.Any(e => e.DashBoardMoviesId == id);
        }
    }
}
