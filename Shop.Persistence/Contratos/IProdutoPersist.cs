using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Contratos
{
    public interface IProdutoPersist
    {
            Task<Produto[]> GetAllProdutosAsync();
            Task<Produto> GetProdutoByIdAsync(int produtoId);
        
    }
}
