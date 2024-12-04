using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Models;
using BurguerManiaAPI.Context;
using BurguerManiaAPI.Dto.Category;
using BurguerManiaAPI.Interfaces.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurguerManiaAPI.Services.Category
{
    public class CategoryService : ICategoryInterface
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<CategoryResponse>>> GetCategories()
        {
            var resposta = new ResponseModel<List<CategoryResponse>>();
            try
            {
                var categories = await _context.Categories
                    .Select(c => new CategoryResponse
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        PathImage = c.PathImage
                    })
                    .ToListAsync();

                if (categories.Count == 0)
                {
                    resposta.Mensagem = "Não há categorias cadastradas!";
                    resposta.Status = false;
                    resposta.StatusCode = 404;
                    return resposta;
                }

                resposta.Dados = categories;
                resposta.Mensagem = "Todas as categorias foram coletadas!";
                resposta.StatusCode = 200;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                resposta.StatusCode = 500;
                return resposta;
            }
        }

        public async Task<ResponseModel<CategoryResponse>> GetCategory(int id)
        {
            var resposta = new ResponseModel<CategoryResponse>();
            try
            {
                var category = await _context.Categories
                    .Where(c => c.Id == id)
                    .Select(c => new CategoryResponse
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        PathImage = c.PathImage
                    })
                    .FirstOrDefaultAsync();

                if (category == null)
                {
                    resposta.Mensagem = "Categoria não encontrada!";
                    resposta.Status = false;
                    resposta.StatusCode = 404;
                    return resposta;
                }

                resposta.Dados = category;
                resposta.Mensagem = "Categoria coletada!";
                resposta.StatusCode = 200;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                resposta.StatusCode = 500;
                return resposta;
            }
        }

        public async Task<ResponseModel<CategoryResponse>> PostCategories(CategoryRequest categoryRequest)
        {
            var resposta = new ResponseModel<CategoryResponse>();
            try
            {
                var category = new CategorysModel
                {
                    Name = categoryRequest.Name,
                    Description = categoryRequest.Description,
                    PathImage = categoryRequest.PathImage
                };

                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                resposta.Dados = new CategoryResponse
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    PathImage = category.PathImage
                };

                resposta.Mensagem = "Categoria adicionada com sucesso!";
                resposta.StatusCode = 201;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                resposta.StatusCode = 500;
                return resposta;
            }
        }

        public async Task<ResponseModel<CategoryResponse>> PutCategories(int id, CategoryRequest categoryRequest)
        {
            var resposta = new ResponseModel<CategoryResponse>();
            try
            {
                var category = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (category == null)
                {
                    resposta.Mensagem = "Categoria não encontrada!";
                    resposta.Status = false;
                    resposta.StatusCode = 404;
                    return resposta;
                }

                category.Name = categoryRequest.Name;
                category.Description = categoryRequest.Description;
                category.PathImage = categoryRequest.PathImage;

                await _context.SaveChangesAsync();

                resposta.Dados = new CategoryResponse
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    PathImage = category.PathImage
                };

                resposta.Mensagem = "Categoria atualizada com sucesso!";
                resposta.StatusCode = 200;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                resposta.StatusCode = 500;
                return resposta;
            }
        }

        public async Task<ResponseModel<CategoryResponse>> DeleteCategories(int id)
        {
            var resposta = new ResponseModel<CategoryResponse>();
            try
            {
                var category = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (category == null)
                {
                    resposta.Mensagem = "Categoria não encontrada!";
                    resposta.Status = false;
                    resposta.StatusCode = 404;
                    return resposta;
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                resposta.Dados = new CategoryResponse
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    PathImage = category.PathImage
                };

                resposta.Mensagem = "Categoria deletada com sucesso!";
                resposta.StatusCode = 200;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                resposta.StatusCode = 500;
                return resposta;
            }
        }
    }
}
