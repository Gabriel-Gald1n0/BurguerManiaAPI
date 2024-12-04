using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Models;
using BurguerManiaAPI.Context;
using BurguerManiaAPI.Dto.UserOrder;
using BurguerManiaAPI.Interfaces.UserOrder;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BurguerManiaAPI.Services.UserOrder
{
    public class UserOrderService : IUserOrderInterface
    {
        private readonly AppDbContext _context;

        public UserOrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<UserOrderResponse>>> GetUserOrders()
        {
            ResponseModel<List<UserOrderResponse>> resposta = new ResponseModel<List<UserOrderResponse>>();
            try
            {
                if (!_context.UsersOrders.Any())
                {
                    resposta.Mensagem = "Não há pedidos cadastrados!";
                    resposta.Status = false;
                    resposta.StatusCode = 404;
                    return resposta;
                }

                var pedidos = await (from uo in _context.UsersOrders
                             join u in _context.Users on uo.UserId equals u.Id
                             join o in _context.Orders on uo.OrderId equals o.Id
                             join s in _context.Status on o.StatusId equals s.Id
                             select new UserOrderResponse
                             {
                                 Id = uo.Id,
                                 UserId = u.Id,
                                 UserName = u.Name,
                                 OrderId = o.Id,
                                 Status = s.Name,
                                 Value = o.Value
                             }).ToListAsync();

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

        public async Task<ResponseModel<UserOrderResponse>> GetUserOrder(int id)
        {
            ResponseModel<UserOrderResponse> resposta = new ResponseModel<UserOrderResponse>();
            try
            {
                var pedido = await (from uo in _context.UsersOrders
                            join u in _context.Users on uo.UserId equals u.Id
                            join o in _context.Orders on uo.OrderId equals o.Id
                            join s in _context.Status on o.StatusId equals s.Id
                            where uo.Id == id
                            select new UserOrderResponse
                            {
                                Id = uo.Id,
                                UserId = u.Id,
                                UserName = u.Name,
                                OrderId = o.Id,
                                Status = s.Name,
                                Value = o.Value
                            }).FirstOrDefaultAsync();

                if(pedido == null)
                {
                    resposta.Mensagem = "Pedido não encontrado!";
                    resposta.StatusCode = 404; 
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = pedido;
                resposta.Mensagem = "Pedido coletado com sucesso!";
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

        public async Task<ResponseModel<UserOrderResponse>> PostUserOrders(UserOrderRequest UserOrderRequest)
        {
            ResponseModel<UserOrderResponse> resposta = new ResponseModel<UserOrderResponse>();
            try
            {
                var pedidoModel = new UserOrdersModel
                {
                    UserId = UserOrderRequest.UserId,
                    OrderId = UserOrderRequest.OrderId
                };
                _context.UsersOrders.Add(pedidoModel);
                await _context.SaveChangesAsync();

                var pedido = await (from uo in _context.UsersOrders
                            join u in _context.Users on uo.UserId equals u.Id
                            join o in _context.Orders on uo.OrderId equals o.Id
                            join s in _context.Status on o.StatusId equals s.Id
                            where uo.Id == pedidoModel.Id
                            select new UserOrderResponse
                            {
                                Id = uo.Id,
                                UserId = u.Id,
                                UserName = u.Name,
                                OrderId = o.Id,
                                Status = s.Name,
                                Value = o.Value
                            }).FirstOrDefaultAsync();

                resposta.Dados = pedido;
                resposta.Mensagem = "Pedido cadastrado com sucesso!";
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

        public async Task<ResponseModel<UserOrderResponse>> PutUserOrders(int id, UserOrderRequest userOrderRequest)
        {
            ResponseModel<UserOrderResponse> resposta = new ResponseModel<UserOrderResponse>();
            try
            {
                var pedidoModel = await _context.UsersOrders.FirstOrDefaultAsync(x => x.Id == id);

                if (pedidoModel == null)
                {
                    resposta.Mensagem = "Pedido não encontrado!";
                    resposta.StatusCode = 404; 
                    resposta.Status = false;
                    return resposta;
                }

                pedidoModel.UserId = userOrderRequest.UserId;
                pedidoModel.OrderId = userOrderRequest.OrderId;
                await _context.SaveChangesAsync();

                var pedidoResponse = await (from uo in _context.UsersOrders
                            join u in _context.Users on uo.UserId equals u.Id
                            join o in _context.Orders on uo.OrderId equals o.Id
                            join s in _context.Status on o.StatusId equals s.Id
                            where uo.Id == pedidoModel.Id
                            select new UserOrderResponse
                            {
                                Id = uo.Id,
                                UserId = u.Id,
                                UserName = u.Name,
                                OrderId = o.Id,
                                Status = s.Name,
                                Value = o.Value
                            }).FirstOrDefaultAsync();
               
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

        public async Task<ResponseModel<UserOrderResponse>> DeleteUserOrders(int id)
        {
            ResponseModel<UserOrderResponse> resposta = new ResponseModel<UserOrderResponse>();
            try
            {
                var pedido = await _context.UsersOrders.FirstOrDefaultAsync(x => x.Id == id);

                if (pedido == null)
                {
                    resposta.Mensagem = "Pedido não encontrado!";
                    resposta.StatusCode = 404; 
                    resposta.Status = false;
                    return resposta;
                }

                var pedidoResponse = await (from uo in _context.UsersOrders
                            join u in _context.Users on uo.UserId equals u.Id
                            join o in _context.Orders on uo.OrderId equals o.Id
                            join s in _context.Status on o.StatusId equals s.Id
                            where uo.Id == pedido.Id
                            select new UserOrderResponse
                            {
                                Id = uo.Id,
                                UserId = u.Id,
                                UserName = u.Name,
                                OrderId = o.Id,
                                Status = s.Name,
                                Value = o.Value
                            }).FirstOrDefaultAsync();                
                
                _context.UsersOrders.Remove(pedido);
                await _context.SaveChangesAsync();

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