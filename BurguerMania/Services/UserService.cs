using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Models;
using BurguerManiaAPI.Context;
using BurguerManiaAPI.Dto.User;
using BurguerManiaAPI.Interfaces.User;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BurguerManiaAPI.Services.User
{
    public class UserService : IUserInterface
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<UsersModel>>> GetUsers()
        {
            ResponseModel<List<UsersModel>> resposta = new ResponseModel<List<UsersModel>>();
            try
            {
                if (_context.Users.Count() == 0)
                {
                    resposta.Mensagem = "Não há clientes cadastrados!";
                    resposta.Status = false;
                    resposta.StatusCode = 404;
                    return resposta;
                }
                var clientes = await _context.Users.ToListAsync();
                resposta.Dados = clientes;
                resposta.Mensagem = "Todos os clientes foram coletados!";
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

        public async Task<ResponseModel<UsersModel>> GetUser(int id)
        {
            ResponseModel<UsersModel> resposta = new ResponseModel<UsersModel>();
            try
            {
                var cliente = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if(cliente == null)
                {
                    resposta.Mensagem = "Cliente não encontrado!";
                    resposta.StatusCode = 404; 
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = cliente;
                resposta.Mensagem = "Cliente encontrado!";
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

        public async Task<ResponseModel<UsersModel>> PostUsers(UserRequest UserRequest)
        {
            ResponseModel<UsersModel> resposta = new ResponseModel<UsersModel>();
            try
            {

                var cliente = new UsersModel
                {
                    Name = UserRequest.Name,
                    Email = UserRequest.Email,
                    Password = UserRequest.Password
                };

                await _context.Users.AddAsync(cliente);
                await _context.SaveChangesAsync();
                resposta.Dados = cliente;
                resposta.Mensagem = "Cliente adicionado com sucesso!";
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
       
        public async Task<ResponseModel<UserResponse>> PutUsers(int id, UserRequest userRequest)
        {
            ResponseModel<UserResponse> resposta = new ResponseModel<UserResponse>();
            try
            {
                var cliente = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (cliente == null)
                {
                    resposta.Mensagem = "Cliente não encontrado!";
                    resposta.StatusCode = 404;
                    resposta.Status = false;
                    return resposta;
                }

                cliente.Name = userRequest.Name;
                cliente.Email = userRequest.Email;
                cliente.Password = userRequest.Password;

                await _context.SaveChangesAsync();

                var clienteResponse = new UserResponse
                {
                    Name = cliente.Name,
                    Email = cliente.Email,
                    Password = cliente.Password
                };

                resposta.Dados = clienteResponse;
                resposta.StatusCode = 200;
                resposta.Mensagem = "Cliente atualizado com sucesso!";
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

        public async Task<ResponseModel<UserResponse>> DeleteUsers(int id)
        {
            ResponseModel<UserResponse> resposta = new ResponseModel<UserResponse>();
            try
            {
                var cliente = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (cliente == null)
                {
                    resposta.Mensagem = "Cliente não encontrado!";
                    resposta.StatusCode = 404;
                    resposta.Status = false;
                    return resposta;
                }

                // Excluindo pedidos ou outras dependências associadas ao cliente
                var pedidos = _context.UsersOrders.Where(o => o.UserId == id);
                _context.UsersOrders.RemoveRange(pedidos);

                // Agora exclui o cliente
                _context.Users.Remove(cliente);
                await _context.SaveChangesAsync();

                var clienteResponse = new UserResponse
                {
                    Name = cliente.Name,
                    Email = cliente.Email
                };

                resposta.Dados = clienteResponse;
                resposta.Mensagem = "Cliente deletado com sucesso!";
                resposta.StatusCode = 200;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.InnerException?.Message ?? ex.Message;
                resposta.Status = false;
                resposta.StatusCode = 500;
                return resposta;
            }
        }
    }
}