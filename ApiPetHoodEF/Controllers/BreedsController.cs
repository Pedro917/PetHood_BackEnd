using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace ApiPetHoodEF.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BreedsController : ControllerBase
    {
        private readonly Context _context;

        public BreedsController(Context context)
        {
            _context = context;
        }

        // GET: api/Breeds
        [HttpGet]
        public async Task<IActionResult> GetBreeds()
        {
            var breeds = await _context.Breeds.ToListAsync();

            return StatusCode(StatusCodes.Status200OK, breeds);
        }

        // GET: api/Breeds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreed(int id)
        {
            try
            {
                var breed = await _context.Breeds.FindAsync(id);

                if (breed == null)
                {
                    return NotFound();
                }

                return Ok(breed);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            
        }

        // PUT: api/Breeds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreed(int id, Breed breed)
        {
            if (id != breed.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "O id da requisição difere do id da Breed");
            }

            _context.Entry(breed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedExists(id))
                {
                    return NotFound("Falha no Banco de dados");
                }
                else
                {
                    throw;
                }
            }

            return Ok(breed);
        }

        // POST: api/Breeds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostBreed(Breed breed)
        {
            try
            {
                _context.Breeds.Add(breed);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBreed", new { id = breed.Id }, breed);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }
        }

        // DELETE: api/Breeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed(int id)
        {
            try
            {
                var breed = await _context.Breeds.FindAsync(id);
                if (breed == null)
                {
                    return NotFound("Categoria não encontrada");
                }

                _context.Breeds.Remove(breed);
                await _context.SaveChangesAsync();

                return Ok(breed);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }
        }

        private bool BreedExists(int id)
        {
            return _context.Breeds.Any(e => e.Id == id);
        }
    }
}
