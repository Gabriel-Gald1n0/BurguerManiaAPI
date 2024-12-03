using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Models;
using BurguerManiaAPI.Context;
using BurguerManiaAPI.Dto.Product;
using BurguerManiaAPI.Interfaces.Product;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BurguerManiaAPI.Services.Product
{
    public class ProductService : IProductInterface
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ProductResponse>>> GetProducts()
        {
            ResponseModel<List<ProductResponse>> resposta = new ResponseModel<List<ProductResponse>>();
            try
            {
                if (!_context.Products.Any())
                {
                    resposta.Mensagem = "Não há produtos cadastrados!";
                    resposta.Status = false;
                    resposta.StatusCode = 404;
                    return resposta;
                }
                var produtos = await _context.Products
                    .Include(x => x.Category)
                    .Select(x => new ProductResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                        CategoryName = x.Category != null ? x.Category.Name : "Sem categoria",
                        PathImage = x.PathImage,
                        BaseDescription = x.BaseDescription,
                        FullDescription = x.FullDescription

                    }).ToListAsync();
                resposta.Dados = produtos;
                resposta.Mensagem = "Todos os produtos foram coletados!";
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

        public async Task<ResponseModel<ProductResponse>> GetProduct(int id)
        {
            ResponseModel<ProductResponse> resposta = new ResponseModel<ProductResponse>();
            try
            {
                var produto = await _context.Products
                    .Include(x => x.Category)
                    .Where(x => x.Id == id)
                    .Select(x => new ProductResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                        CategoryName = x.Category != null ? x.Category.Name : "Sem categoria",
                        PathImage = x.PathImage,
                        BaseDescription = x.BaseDescription,
                        FullDescription = x.FullDescription
                    }).FirstOrDefaultAsync();

                if(produto == null)
                {
                    resposta.Mensagem = "Produto não encontrado!";
                    resposta.StatusCode = 404; 
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = produto;
                resposta.Mensagem = "Produto coletado!";
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

        public async Task<ResponseModel<ProductResponse>> PostProducts(ProductRequest productRequest)
        {
            ResponseModel<ProductResponse> resposta = new ResponseModel<ProductResponse>();
            try
            {
                ProductsModel produto = new ProductsModel();
                produto.Name = productRequest.Name;
                produto.Price = productRequest.Price;
                produto.CategoryId = productRequest.CategoryId;
                produto.PathImage = productRequest.PathImage;
                produto.BaseDescription = productRequest.BaseDescription;
                produto.FullDescription = productRequest.FullDescription;
                _context.Products.Add(produto);
                await _context.SaveChangesAsync();

                var Category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == productRequest.CategoryId);
                if (Category == null)
                {
                    resposta.Mensagem = "Categoria inválida!";
                    resposta.Status = false;
                    resposta.StatusCode = 400;
                    return resposta;
                }

                var produtoResponse = new ProductResponse
                {
                    Id = produto.Id,
                    Name = produto.Name,
                    Price = produto.Price,
                    CategoryName = produto.Category != null ? produto.Category.Name : "Sem categoria",
                    PathImage = produto.PathImage,
                    BaseDescription = produto.BaseDescription,
                    FullDescription = produto.FullDescription
                };

                resposta.Dados = produtoResponse;
                resposta.Mensagem = "Produto cadastrado!";
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

        public async Task<ResponseModel<ProductResponse>> PutProducts(int id, ProductRequest productRequest)
        {
            ResponseModel<ProductResponse> resposta = new ResponseModel<ProductResponse>();
            try
            {
                var produtoAtual = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

                if (produtoAtual == null)
                {
                    resposta.Mensagem = "Produto não encontrado!";
                    resposta.StatusCode = 404;
                    resposta.Status = false;
                    return resposta;
                }

                var categoria = await _context.Categories.FirstOrDefaultAsync(x => x.Id == productRequest.CategoryId);
                if (categoria == null)
                {
                    resposta.Mensagem = "Categoria inválida!";
                    resposta.Status = false;
                    resposta.StatusCode = 400;
                    return resposta;
                }

                produtoAtual.Name = productRequest.Name;
                produtoAtual.Price = productRequest.Price;
                produtoAtual.BaseDescription = productRequest.BaseDescription;
                produtoAtual.FullDescription = productRequest.FullDescription;
                produtoAtual.CategoryId = productRequest.CategoryId;
                produtoAtual.PathImage = productRequest.PathImage;

                await _context.SaveChangesAsync();

                // Criar o response com os dados atualizados
                var produtoResponse = new ProductResponse
                {
                    Id = produtoAtual.Id,
                    Name = produtoAtual.Name,
                    Price = produtoAtual.Price,
                    CategoryName = produtoAtual.Category != null ? produtoAtual.Category.Name : "Sem categoria",
                    PathImage = produtoAtual.PathImage,
                    BaseDescription = produtoAtual.BaseDescription,
                    FullDescription = produtoAtual.FullDescription
                };

                resposta.Dados = produtoResponse;
                resposta.Mensagem = "Produto atualizado!";
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


        public async Task<ResponseModel<ProductResponse>> DeleteProducts(int id)
        {
            ResponseModel<ProductResponse> resposta = new ResponseModel<ProductResponse>();
            try
            {
                var produto = await _context.Products
                    .Include(x => x.Category) 
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (produto == null)
                {
                    resposta.Mensagem = "Produto não encontrado!";
                    resposta.StatusCode = 404;
                    resposta.Status = false;
                    return resposta;
                }


                _context.Products.Remove(produto);
                await _context.SaveChangesAsync();

                
                var produtoResponse = new ProductResponse
                {
                    Id = produto.Id,
                    Name = produto.Name,
                    Price = produto.Price,
                    CategoryName = produto.Category != null ? produto.Category.Name : "Sem categoria",
                    PathImage = produto.PathImage,
                    BaseDescription = produto.BaseDescription,
                    FullDescription = produto.FullDescription
                };

                    resposta.Dados = produtoResponse;
                    resposta.Mensagem = "Produto deletado!";
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