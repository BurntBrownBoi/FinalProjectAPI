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
    public class FavoriteCarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavoriteCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteCar>>> GetFavoriteCars()
        {
          if (_context.FavoriteCars == null)
          {
              return NotFound();
          }
            return await _context.FavoriteCars.ToListAsync();
        }

        // GET: api/FavoriteCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteCar>> GetFavoriteCar(int id)
        {
          if (_context.FavoriteCars == null)
          {
              return Ok(await _context.FavoriteCars.Take(5).ToListAsync());
          }
            var favoriteCar = await _context.FavoriteCars.FindAsync(id);

            if (favoriteCar == null)
            {
                return NotFound();
            }

            return favoriteCar;
        }

        // PUT: api/FavoriteCars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteCar(int id, FavoriteCar favoriteCar)
        {
            if (id != favoriteCar.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteCarExists(id))
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

        // POST: api/FavoriteCars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteCar>> PostFavoriteCar(FavoriteCar favoriteCar)
        {
          if (_context.FavoriteCars == null)
          {
              return Problem("Entity set 'ApplicationDbContext.FavoriteCars'  is null.");
          }
            _context.FavoriteCars.Add(favoriteCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoriteCar", new { id = favoriteCar.Id }, favoriteCar);
        }

        // DELETE: api/FavoriteCars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteCar(int id)
        {
            if (_context.FavoriteCars == null)
            {
                return NotFound();
            }
            var favoriteCar = await _context.FavoriteCars.FindAsync(id);
            if (favoriteCar == null)
            {
                return NotFound();
            }

            _context.FavoriteCars.Remove(favoriteCar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteCarExists(int id)
        {
            return (_context.FavoriteCars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
