using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application;
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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService,
            IWebHostEnvironment hostEnvironment)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produto = await _produtoService.GetAllProdutosAsync();
                if (produto == null) return NoContent();

                return Ok(produto);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar os produtos. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var produto = await _produtoService.GetProdutoByIdAsync(id);
                if (produto == null) return NoContent();

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro ao recuperar o produto. Erro:{ex.Message}");
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProdutoDto model)
        {
            try
            {
                var produto = await _produtoService.AddProduto(model);
                if (produto == null) return NoContent();

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro ao cadastrar o produto. Erro:{ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProdutoDto model)
        {
            try
            {
                var produto = await _produtoService.UpdateProduto(id,model);
                if (produto == null) return NoContent();

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro au atualizar o produto selecionado. Erro:{ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var produto =  _produtoService.GetProdutoByIdAsync(id);
                if (produto == null) NoContent();

                if(await _produtoService.DeleteProduto(id))
                {
                    return Ok(produto);
                }
                else
                {
                    throw new Exception("Ocorreu um erro ao deletar o produto!");
                }

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar o produto. Erro: {ex.Message}");
            }
        }

    }
}
