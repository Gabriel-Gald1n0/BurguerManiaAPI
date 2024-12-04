using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Models;
using BurguerManiaAPI.Context;
using BurguerManiaAPI.Dto.OrderProduct;
using BurguerManiaAPI.Interfaces.OrderProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurguerManiaAPI.Services.OrderProduct
{
    public class OrderProductService : IOrderProductInterface
    {
        private readonly AppDbContext _context;

        public OrderProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<OrderProductResponse>>> GetOrderProducts()
        {
            var resposta = new ResponseModel<List<OrderProductResponse>>();
            try
            {
                var orderProducts = await (from op in _context.OrdersProducts
                             join p in _context.Products on op.ProductId equals p.Id
                             join o in _context.Orders on op.OrderId equals o.Id
                             join s in _context.Status on o.StatusId equals s.Id
                             select new OrderProductResponse
                             {
                                 Id = op.Id,
                                 ProductId = p.Id,
                                 ProductName = p.Name,
                                 OrderId = o.Id,
                                 Status = s.Name,
                                 Value = o.Value
                             }).ToListAsync();

                if (orderProducts.Count == 0)
                {
                    resposta.Mensagem = "Não há produtos de pedidos cadastrados!";
                    resposta.Status = false;
                    resposta.StatusCode = 404;
                    return resposta;
                }

                resposta.Dados = orderProducts;
                resposta.Mensagem = "Todos os produtos de pedidos foram coletados!";
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

        public async Task<ResponseModel<OrderProductResponse>> GetOrderProduct(int id)
        {
            var resposta = new ResponseModel<OrderProductResponse>();
            try
            {

                var orderProduct = await (from op in _context.OrdersProducts
                             join p in _context.Products on op.ProductId equals p.Id
                             join o in _context.Orders on op.OrderId equals o.Id
                             join s in _context.Status on o.StatusId equals s.Id
                             where op.Id == id
                             select new OrderProductResponse
                             {
                                 Id = op.Id,
                                 ProductId = p.Id,
                                 ProductName = p.Name,
                                 OrderId = o.Id,
                                 Status = s.Name,
                                 Value = o.Value
                             }).FirstOrDefaultAsync(); 

                if (orderProduct == null)
                {
                    resposta.Mensagem = "Produto de pedido não encontrado!";
                    resposta.Status = false;
                    resposta.StatusCode = 404;
                    return resposta;
                }

                resposta.Dados = orderProduct;
                resposta.Mensagem = "Produto de pedido coletado!";
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

        public async Task<ResponseModel<OrderProductResponse>> PostOrderProducts(OrderProductRequest orderProductRequest)
        {
            var resposta = new ResponseModel<OrderProductResponse>();
            try
            {
                var orderProduct = new OrderProductsModel
                {
                    OrderId = orderProductRequest.OrderId,
                    ProductId = orderProductRequest.ProductId
                };

                _context.OrdersProducts.Add(orderProduct);
                await _context.SaveChangesAsync();

                var OrderProductResponse = await (from op in _context.OrdersProducts
                             join p in _context.Products on op.ProductId equals p.Id
                             join o in _context.Orders on op.OrderId equals o.Id
                             join s in _context.Status on o.StatusId equals s.Id
                             where op.Id == orderProduct.Id
                             select new OrderProductResponse
                             {
                                 Id = op.Id,
                                 ProductId = p.Id,
                                 ProductName = p.Name,
                                 OrderId = o.Id,
                                 Status = s.Name,
                                 Value = o.Value
                             }).FirstOrDefaultAsync(); 

                resposta.Dados = OrderProductResponse;
                resposta.Mensagem = "Produto de pedido cadastrado com sucesso!";
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

        public async Task<ResponseModel<OrderProductResponse>> PutOrderProducts(int id, OrderProductRequest orderProductRequest)
        {
            var resposta = new ResponseModel<OrderProductResponse>();
            try
            {
                var orderProduct = await _context.OrdersProducts
                    .FirstOrDefaultAsync(op => op.OrderId == id);

                if (orderProduct == null)
                {
                    resposta.Mensagem = "Produto de pedido não encontrado!";
                    resposta.Status = false;
                    resposta.StatusCode = 404;
                    return resposta;
                }

                orderProduct.ProductId = orderProductRequest.ProductId;
                orderProduct.OrderId = orderProductRequest.OrderId;

                await _context.SaveChangesAsync();

                var OrderProductResponse = await (from op in _context.OrdersProducts
                             join p in _context.Products on op.ProductId equals p.Id
                             join o in _context.Orders on op.OrderId equals o.Id
                             join s in _context.Status on o.StatusId equals s.Id
                             where op.Id == orderProduct.Id
                             select new OrderProductResponse
                             {
                                 Id = op.Id,
                                 ProductId = p.Id,
                                 ProductName = p.Name,
                                 OrderId = o.Id,
                                 Status = s.Name,
                                 Value = o.Value
                             }).FirstOrDefaultAsync(); 

                resposta.Dados = OrderProductResponse;
                resposta.Mensagem = "Produto de pedido atualizado com sucesso!";
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

        public async Task<ResponseModel<OrderProductResponse>> DeleteOrderProducts(int id)
        {
            var resposta = new ResponseModel<OrderProductResponse>();
            try
            {
                var orderProduct = await _context.OrdersProducts
                    .FirstOrDefaultAsync(op => op.OrderId == id);

                if (orderProduct == null)
                {
                    resposta.Mensagem = "Produto de pedido não encontrado!";
                    resposta.Status = false;
                    resposta.StatusCode = 404;
                    return resposta;
                }

                var OrderProductResponse = await (from op in _context.OrdersProducts
                             join p in _context.Products on op.ProductId equals p.Id
                             join o in _context.Orders on op.OrderId equals o.Id
                             join s in _context.Status on o.StatusId equals s.Id
                             where op.Id == orderProduct.Id
                             select new OrderProductResponse
                             {
                                 Id = op.Id,
                                 ProductId = p.Id,
                                 ProductName = p.Name,
                                 OrderId = o.Id,
                                 Status = s.Name,
                                 Value = o.Value
                             }).FirstOrDefaultAsync(); 

                _context.OrdersProducts.Remove(orderProduct);
                await _context.SaveChangesAsync();

                resposta.Dados = OrderProductResponse;
                resposta.Mensagem = "Produto de pedido deletado com sucesso!";
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
