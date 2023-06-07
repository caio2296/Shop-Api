using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using Shop.Persistence.Contexto;
using Shop.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence
{
    public class CategoriaPersist : ICategoriaPersist
    {
        private readonly ShopContext _context;

        public CategoriaPersist(ShopContext context)
        {
            _context = context;
        }

        public async Task<Categoria[]> GetAllCategoriasAsync()
        {
            IQueryable<Categoria> query = _context.categorias;
            query = query.AsNoTracking()
                .OrderBy(c=> c.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Categoria> GetCategoriaByIdAsync(int categoriaId)
        {
            IQueryable<Categoria> query = _context.categorias;
            query = query.AsNoTracking()
                 .OrderBy(c => c.Id)
                 .Where(c => c.Id == categoriaId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
