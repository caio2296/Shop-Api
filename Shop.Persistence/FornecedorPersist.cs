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
    public class FornecedorPersist : IFornecedorPersist
    {
        private readonly ShopContext _context;

        public FornecedorPersist(ShopContext context)
        {
            _context = context;
        }
        public async Task<Fornecedor[]> GetAllFornecedorsAsync()
        {
            IQueryable<Fornecedor> query = _context.fornecedores;

            query = query.AsNoTracking()
                .OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Fornecedor> GetFornecedorByIdAsync(int fornecedorId)
        {
            IQueryable<Fornecedor> query = _context.fornecedores;

            query = query.AsNoTracking()
                        .OrderBy(f => f.Id)
                             .Where(j => j.Id == fornecedorId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
