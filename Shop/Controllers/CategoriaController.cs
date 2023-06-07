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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService,
            IWebHostEnvironment hostEnvironment)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categorias = await _categoriaService.GetAllCategoriasAsync();
                if (categorias == null) return NoContent();

                return Ok(categorias);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar as categorias. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
                if (categoria == null) return NoContent();

                return Ok(categoria);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar a categoria. Erro:{ex.Message}");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post(CategoriaDto model)
        {
            try
            {
                var categoria = await _categoriaService.AddCategoria(model);
                if (categoria == null) return NoContent();

                return Ok(categoria);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao cadastrar a categoria. Erro:{ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoriaDto model)
        {
            try
            {
                var categoria = await _categoriaService.UpdateCategoria(id, model);
                if (categoria == null) return NoContent();

                return Ok(categoria);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro au atualizar a categoria selecionada. Erro:{ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var categoria = _categoriaService.GetCategoriaByIdAsync(id);
                if (categoria == null) NoContent();

                if (await _categoriaService.DeleteCategoria(id))
                {
                    return Ok(categoria);
                }
                else
                {
                    throw new Exception("Ocorreu um erro ao deletar a categoria!");
                }

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar a categoria. Erro: {ex.Message}");
            }
        }
    }
}
