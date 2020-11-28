using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PetHoodRepository : IPetHoodRepository
    {
        private readonly Context _context;

        public PetHoodRepository(Context context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Pet[]> GetAllPetAsync()
        {
            IQueryable<Pet> query = _context.Pets
                .Include(c => c.Raca);

            return await query.ToArrayAsync();
        }

        public async Task<Pet[]> GetAllPetAsyncByEspecie(string especie)
        {
            IQueryable<Pet> query = _context.Pets
                .Include(c => c.Raca);

            query = query.Where(c => c.Especie.ToLower().Contains(especie.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Pet> GetPetAsyncById(int petId)
        {
            IQueryable<Pet> query = _context.Pets
                .Include(c => c.Raca);

            query = query.Where(c => c.Id == petId);

            return await query.FirstOrDefaultAsync();
        }

        

    }
}
