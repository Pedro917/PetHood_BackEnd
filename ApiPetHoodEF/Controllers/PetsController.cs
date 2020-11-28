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
    public class PetsController : ControllerBase
    {
        private readonly Context _context;

        public PetsController(Context context)
        {
            _context = context;
        }

        // GET: v1/Pets
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pets = await _context.Pets.ToListAsync();

            return StatusCode(StatusCodes.Status200OK, pets);
        }

        // GET: v1/Pets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pet = await _context.Pets.FindAsync(id);

                if (pet == null)
                {
                    return NotFound();
                }

                return Ok(pet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }


        }

        // PUT: v1/Pets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "O id da requisição difere do id do Pet");
            }

            try
            {
                _context.Entry(pet).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
                {
                    return NotFound("Pet Não Encontrado");
                }
                else
                {
                    throw;
                }
            }

            return BadRequest(pet);
        }

        // POST: v1/Pets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> Post(Pet pet)
        {
            try
            {
                _context.Pets.Add(pet);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, "Pet inserido no sistema");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }
        }

        // DELETE: v1/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pet = await _context.Pets.FindAsync(id);
                if (pet == null)
                {
                    return NotFound("Pet não encontrado");
                }

                _context.Pets.Remove(pet);
                await _context.SaveChangesAsync();

                return Ok(pet);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }
    }
}
