using AutoMapper;
using Shop.Application.Contratos;
using Shop.Application.Dtos;
using Shop.Domain;
using Shop.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ICategoriaPersist _categoriaPersist;
        private readonly IMapper _mapper;
        public CategoriaService(IGeralPersist geralPersist,
            ICategoriaPersist categoriaPersist,
            IMapper mapper)
        {
            _geralPersist = geralPersist;
            _categoriaPersist = categoriaPersist;
            _mapper = mapper;
        }
        public async Task<CategoriaDto> AddCategoria(CategoriaDto model)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(model);
                _geralPersist.Add(categoria);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var categoriaRetorno = await _categoriaPersist.GetCategoriaByIdAsync(categoria.Id);
                    return _mapper.Map<CategoriaDto>(categoriaRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCategoria(int categoriarId)
        {
            try
            {
                var categoria = await _categoriaPersist.GetCategoriaByIdAsync(categoriarId);
                if (categoria == null) throw new Exception("Erro ao excluir a categoria. Categoria não encontrado!");
                _geralPersist.Delete(categoria);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto[]> GetAllCategoriasAsync()
        {
            try
            {
                var categorias = await _categoriaPersist.GetAllCategoriasAsync();
                if (categorias == null) return null;
                var resultado = _mapper.Map<CategoriaDto[]>(categorias);
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto> GetCategoriaByIdAsync(int categoriaId)
        {
             try
            {
                var categoria = await _categoriaPersist.GetCategoriaByIdAsync(categoriaId);
                if (categoria == null) return null;
                var resultado = _mapper.Map<CategoriaDto>(categoria);
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto> UpdateCategoria(int categoriaId, CategoriaDto model)
        {
            try
            {
                var categoria = await _categoriaPersist.GetCategoriaByIdAsync(categoriaId);
                if (categoria == null) return null;

                model.Id = categoria.Id;
                _mapper.Map(model, categoria);
                _geralPersist.Update(categoria);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var categoriaRetorno = await _categoriaPersist.GetCategoriaByIdAsync(categoriaId);
                    return _mapper.Map<CategoriaDto>(categoriaRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
