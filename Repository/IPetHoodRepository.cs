using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPetHoodRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Pet[]> GetAllPetAsyncByEspecie(string especie);
        Task<Pet[]> GetAllPetAsync();
        Task<Pet> GetPetAsyncById(int PetId);
    }
}
