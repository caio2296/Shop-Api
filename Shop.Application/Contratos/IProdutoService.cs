using Shop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contratos
{
    public interface IProdutoService
    {
        Task<ProdutoDto> AddProduto(ProdutoDto model);
        Task<ProdutoDto> UpdateProduto(int produtoId, ProdutoDto model);
        Task<bool> DeleteProduto(int produtoId);
        Task<ProdutoDto[]> GetAllProdutosAsync();
        Task<ProdutoDto> GetProdutoByIdAsync(int produtoId);
    }
}
