using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectAPI.Models;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteMoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavoriteMoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteMovies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteMovie>>> GetFavoriteMovies()
        {
          if (_context.FavoriteMovies == null)
          {
              return NotFound();
          }
            return await _context.FavoriteMovies.ToListAsync();
        }

        // GET: api/FavoriteMovies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteMovie>> GetFavoriteMovie(int id)
        {
          if (_context.FavoriteMovies == null)
          {
              return NotFound();
          }
            var favoriteMovie = await _context.FavoriteMovies.FindAsync(id);

            if (favoriteMovie == null)
            {
                return NotFound();
            }

            return favoriteMovie;
        }

        // PUT: api/FavoriteMovies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteMovie(int id, FavoriteMovie favoriteMovie)
        {
            if (id != favoriteMovie.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteMovieExists(id))
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

        // POST: api/FavoriteMovies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteMovie>> PostFavoriteMovie(FavoriteMovie favoriteMovie)
        {
          if (_context.FavoriteMovies == null)
          {
              return Problem("Entity set 'ApplicationDbContext.FavoriteMovies'  is null.");
          }
            _context.FavoriteMovies.Add(favoriteMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoriteMovie", new { id = favoriteMovie.Id }, favoriteMovie);
        }

        // DELETE: api/FavoriteMovies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteMovie(int id)
        {
            if (_context.FavoriteMovies == null)
            {
                return NotFound();
            }
            var favoriteMovie = await _context.FavoriteMovies.FindAsync(id);
            if (favoriteMovie == null)
            {
                return NotFound();
            }

            _context.FavoriteMovies.Remove(favoriteMovie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteMovieExists(int id)
        {
            return (_context.FavoriteMovies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
