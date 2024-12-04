using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Context;
using BurguerManiaAPI.Models;
using BurguerManiaAPI.Dto.Category;
using BurguerManiaAPI.Interfaces.Category;

namespace BurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ICategoryInterface _categoryInterface;

        public CategorysController(ICategoryInterface categoryInterface)
        {
            _categoryInterface = categoryInterface;
        }

        // GET: api/Categorys
        [HttpGet("GetCategorys")]
        public async Task<ActionResult<ResponseModel<List<CategoryResponse>>>> GetCategorys()
        {
            var categorys = await _categoryInterface.GetCategories();
            if (!categorys.Status)
            {
               return StatusCode(categorys.StatusCode, new { status = categorys.StatusCode, erros = categorys.Mensagem });
            }
            
            return Ok(categorys);
        }

        // GET: api/Categorys/5
        [HttpGet("GetCategory/{id}")]
        public async Task<ActionResult<ResponseModel<CategoryResponse>>> GetCategory(int id)
        {
            var category = await _categoryInterface.GetCategory(id);
            if (!category.Status)
            {
               return StatusCode(category.StatusCode, new { status = category.StatusCode, erros = category.Mensagem });
            }

            return Ok(category);
        }

        // PUT: api/Categorys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCategorys/{id}")]
        public async Task<ActionResult<ResponseModel<CategoryResponse>>> PutCategorys(int id, CategoryRequest categoryRequest)
        {
            if (!ModelState.IsValid)
            {
                // Caso o modelo não seja válido, retorna uma resposta com as mensagens de erro
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { erros = errorMessages });
            }
            
            var category = await _categoryInterface.PutCategories(id, categoryRequest);
            
            if (!category.Status)
            {
               return StatusCode(category.StatusCode, new { status = category.StatusCode, erros = category.Mensagem });
            }
            return Ok(category);
        }

        // POST: api/Categorys
        [HttpPost("PostCategorys")]
        public async Task<ActionResult<ResponseModel<CategoryResponse>>> PostCategorys(CategoryRequest categoryRequest)
        {
            if (!ModelState.IsValid)
            {
                // Caso o modelo não seja válido, retorna uma resposta com as mensagens de erro
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { erros = errorMessages });
            }
            
            var category = await _categoryInterface.PostCategories(categoryRequest);
            
            if (!category.Status)
            {
               return StatusCode(category.StatusCode, new { status = category.StatusCode, erros = category.Mensagem });
            }
            return Ok(category);
        }

        // DELETE: api/Categorys/5
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<ActionResult<ResponseModel<CategoryResponse>>> DeleteCategory(int id)
        {
            var category = await _categoryInterface.DeleteCategories(id);
            if (!category.Status)
            {
               return StatusCode(category.StatusCode, new { status = category.StatusCode, erros = category.Mensagem });
            }

            return Ok(category);
        }
    }
}
