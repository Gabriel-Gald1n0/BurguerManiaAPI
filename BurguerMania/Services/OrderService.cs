using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Models;
using BurguerManiaAPI.Context;
using BurguerManiaAPI.Dto.Order;
using BurguerManiaAPI.Interfaces.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurguerManiaAPI.Services.Order
{
    public class OrderService : IOrderInterface
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<OrderResponse>>> GetOrders()
        {
            var resposta = new ResponseModel<List<OrderResponse>>();
            try
            {
                var pedidos = await _context.Orders
                    .Select(o => new OrderResponse
                    {
                        Id = o.Id,
                        StatusId = o.StatusId,
                        Status = o.Status != null ? o.Status.Name : "Status não encontrado",  
                        Value = o.Value
                    })
                    .ToListAsync();

                if (!pedidos.Any())
                {
                    resposta.Mensagem = "Não há pedidos cadastrados!";
                    resposta.Status = false;
                    resposta.StatusCode = 404;
                    return resposta;
                }

                resposta.Dados = pedidos;
                resposta.Mensagem = "Todos os pedidos foram coletados!";
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

        public async Task<ResponseModel<OrderResponse>> GetOrder(int id)
        {
            var resposta = new ResponseModel<OrderResponse>();
            try
            {
                var pedido = await _context.Orders
                    .Where(o => o.Id == id)
                    .Select(o => new OrderResponse
                    {
                        Id = o.Id,
                        StatusId = o.StatusId,
                        Status = o.Status != null ? o.Status.Name : "Status não encontrado",  
                        Value = o.Value
                    })
                    .FirstOrDefaultAsync();

                if (pedido == null)
                {
                    resposta.Mensagem = "Pedido não encontrado!";
                    resposta.StatusCode = 404;
                    resposta.Status = false;
                    return resposta;
                }

                resposta.Dados = pedido;
                resposta.Mensagem = "Pedido encontrado!";
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

        public async Task<ResponseModel<OrderResponse>> PostOrders(OrderRequest orderRequest)
        {
            var resposta = new ResponseModel<OrderResponse>();
            try
            {
                var pedido = new OrdersModel
                {
                    StatusId = orderRequest.StatusId,
                    Value = orderRequest.Value
                };

                _context.Orders.Add(pedido);
                await _context.SaveChangesAsync();

                var pedidoResponse = new OrderResponse
                {
                    Status = pedido.Status != null ? pedido.Status.Name : "Status não encontrado",  
                    Value = pedido.Value
                };

                resposta.Dados = pedidoResponse;
                resposta.Mensagem = "Pedido criado com sucesso!";
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

        public async Task<ResponseModel<OrderResponse>> PutOrders(int id, OrderRequest orderRequest)
        {
            var resposta = new ResponseModel<OrderResponse>();
            try
            {
                var pedido = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
                if (pedido == null)
                {
                    resposta.Mensagem = "Pedido não encontrado!";
                    resposta.StatusCode = 404;
                    resposta.Status = false;
                    return resposta;
                }

                pedido.StatusId = orderRequest.StatusId;
                pedido.Value = orderRequest.Value;

                await _context.SaveChangesAsync();

                var pedidoResponse = new OrderResponse
                {
                    Status = pedido.Status != null ? pedido.Status.Name : "Status não encontrado",  
                    Value = pedido.Value
                };

                resposta.Dados = pedidoResponse;
                resposta.Mensagem = "Pedido atualizado com sucesso!";
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

        public async Task<ResponseModel<OrderResponse>> DeleteOrders(int id)
        {
            var resposta = new ResponseModel<OrderResponse>();
            try
            {
                var pedido = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

                if (pedido == null)
                {
                    resposta.Mensagem = "Pedido não encontrado!";
                    resposta.StatusCode = 404;
                    resposta.Status = false;
                    return resposta;
                }

                _context.Orders.Remove(pedido);
                await _context.SaveChangesAsync();

                var pedidoResponse = new OrderResponse
                {
                    Id = pedido.Id,
                    Status = pedido.Status != null ? pedido.Status.Name : "Status não encontrado",  
                    Value = pedido.Value
                };

                resposta.Dados = pedidoResponse;
                resposta.Mensagem = "Pedido deletado com sucesso!";
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
