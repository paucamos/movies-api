using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Api.Models;

namespace Movies_Api.Controllers
{
    public class Movies : BaseApiController
    {
        private readonly MovieContext _context;

        public Movies(MovieContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(long id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(long id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);

            /*
                The method gets the value of the movie item from the body of the HTTP request.
                
                The CreatedAtAction method:
                    - Returns an HTTP 201 status code if successful. HTTP 201 is the standard response for an HTTP POST method that creates a new resource on the server.
                    - Adds a Location header to the response. The Location header specifies the URI of the newly created movie item. For more information, see 10.2.2 201 Created.
                    - References the Movie action to create the Location header's URI. The C# nameof keyword is used to avoid hard-coding the action name in the CreatedAtAction call.
            */
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(long id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(long id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
