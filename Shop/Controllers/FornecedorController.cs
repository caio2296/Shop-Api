using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Contratos;
using Shop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService,
            IWebHostEnvironment hostEnvironment)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var fornecedores = await _fornecedorService.GetAllFornecedoresAsync();
                if (fornecedores == null) return NoContent();

                return Ok(fornecedores);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar os fornecedores. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var fornecedor = await _fornecedorService.GetFornecedorByIdAsync(id);
                if (fornecedor == null) return NoContent();

                return Ok(fornecedor);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar o fornecedor. Erro:{ex.Message}");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post(FornecedorDto model)
        {
            try
            {
                var fornecedor = await _fornecedorService.AddFornecedor(model);
                if (fornecedor == null) return NoContent();

                return Ok(fornecedor);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao cadastrar o fornecedor. Erro:{ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FornecedorDto model)
        {
            try
            {
                var fornecedor = await _fornecedorService.UpdateFornecedor(id, model);
                if (fornecedor == null) return NoContent();

                return Ok(fornecedor);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro au atualizar o fornecedor selecionado. Erro:{ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var fornecedor =  _fornecedorService.GetFornecedorByIdAsync(id);
                if (fornecedor == null) NoContent();

                if (await _fornecedorService.DeleteFornecedor(id))
                {
                    return Ok(fornecedor);
                }
                else
                {
                    throw new Exception("Ocorreu um erro ao deletar o fornecedor!");
                }

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar o fornecedor. Erro: {ex.Message}");
            }
        }

    }
}
