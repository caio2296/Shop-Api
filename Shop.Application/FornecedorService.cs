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
    public class FornecedorService : IFornecedorService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IFornecedorPersist _fornecedorPersist;
        private readonly IMapper _mapper;

        public FornecedorService(IGeralPersist geralPersist,
            IFornecedorPersist fornecedorPersist,
            IMapper mapper)
        {
            _geralPersist = geralPersist;
            _fornecedorPersist = fornecedorPersist;
            _mapper = mapper;
        }
        public async Task<FornecedorDto> AddFornecedor(FornecedorDto model)
        {
            try
            {
                var fornecedor = _mapper.Map<Fornecedor>(model);
                _geralPersist.Add(fornecedor);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var fornecedorRetorno = await _fornecedorPersist.GetFornecedorByIdAsync(fornecedor.Id);
                    return  _mapper.Map<FornecedorDto>(fornecedorRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteFornecedor(int fornecedorId)
        {
            try
            {
                var fornecedor = await _fornecedorPersist.GetFornecedorByIdAsync(fornecedorId);
                if (fornecedor == null) throw new Exception("Erro ao excluir o fornecedor. Fornecedor não encontrado!");
                _geralPersist.Delete(fornecedor);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<FornecedorDto[]> GetAllFornecedoresAsync()
        {
            try
            {
                var fornecedores = await _fornecedorPersist.GetAllFornecedorsAsync();
                if (fornecedores == null) return null;
                var resultado = _mapper.Map<FornecedorDto[]>(fornecedores);
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<FornecedorDto> GetFornecedorByIdAsync(int fornecedorId)
        {
            try
            {
                var fornecedor = await _fornecedorPersist.GetFornecedorByIdAsync(fornecedorId);
                if (fornecedor == null) return null;
                var resultado = _mapper.Map<FornecedorDto>(fornecedor);
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<FornecedorDto> UpdateFornecedor(int fornecedorId, FornecedorDto model)
        {
            try
            {
                var fornecedor = await _fornecedorPersist.GetFornecedorByIdAsync(fornecedorId);
                if (fornecedor == null) return null;

                model.Id = fornecedor.Id;
                _mapper.Map(model, fornecedor);
                _geralPersist.Update(fornecedor);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var produtoRetorno = await _fornecedorPersist.GetFornecedorByIdAsync(fornecedorId);
                    return _mapper.Map<FornecedorDto>(produtoRetorno);
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
