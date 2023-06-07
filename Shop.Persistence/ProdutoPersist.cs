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
    public class ProdutoPersist : IProdutoPersist
    {
        private readonly ShopContext _context;

        public ProdutoPersist(ShopContext context)
        {
            _context = context;
        }

        public async Task<Produto[]> GetAllProdutosAsync()
        {
            IQueryable<Produto> query = _context.produtos;

            query = query
                .AsNoTracking()
               
                .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public  Task<Produto> GetProdutoByIdAsync(int produtoId)
        {

            IQueryable<Produto> query = _context.produtos;
            query = query.AsNoTracking()
                 .OrderBy(e => e.Id)
                  .Where(p => p.Id == produtoId);
            return query.FirstOrDefaultAsync();
        }
    }
}
