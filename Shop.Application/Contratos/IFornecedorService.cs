using Shop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contratos
{
    public interface IFornecedorService
    {
        Task<FornecedorDto> AddFornecedor(FornecedorDto model);
        Task<FornecedorDto> UpdateFornecedor(int fornecedorId, FornecedorDto model);
        Task<bool> DeleteFornecedor(int fornecedorId);
        Task<FornecedorDto[]> GetAllFornecedoresAsync();
        Task<FornecedorDto> GetFornecedorByIdAsync(int fornecedorId);
    }
}
