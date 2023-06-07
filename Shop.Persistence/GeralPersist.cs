using Shop.Persistence.Contexto;
using Shop.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace Shop.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly ShopContext _context;
        public GeralPersist(ShopContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync())> 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
