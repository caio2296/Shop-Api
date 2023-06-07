using Shop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contratos
{
    public interface ICategoriaService
    {
        Task<CategoriaDto> AddCategoria(CategoriaDto model);
        Task<CategoriaDto> UpdateCategoria(int categoriaId, CategoriaDto model);
        Task<bool> DeleteCategoria(int categoriarId);
        Task<CategoriaDto[]> GetAllCategoriasAsync();
        Task<CategoriaDto> GetCategoriaByIdAsync(int categoriaId);
    }
}
