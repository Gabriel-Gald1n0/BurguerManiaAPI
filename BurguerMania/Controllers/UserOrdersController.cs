using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Context;
using BurguerManiaAPI.Models;
using BurguerManiaAPI.Dto.UserOrder;
using BurguerManiaAPI.Interfaces.UserOrder;


namespace BurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrdersController : ControllerBase
    {
       private readonly IUserOrderInterface _userOrderInterface;

       public UserOrdersController(IUserOrderInterface userOrderInterface)
       {
           _userOrderInterface = userOrderInterface;
       }

         // GET: api/UserOrders 
        [HttpGet("GetUserOrders")]
        public async Task<ActionResult<ResponseModel<List<UserOrdersModel>>>> GetUserOrders()
        {
            var userOrders = await _userOrderInterface.GetUserOrders();
            if (!userOrders.Status && userOrders.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = userOrders.Mensagem });
            }

            return Ok(userOrders);
        }

        // GET: api/UserOrders/5
        [HttpGet("GetUserOrder/{id}")]
        public async Task<ActionResult<ResponseModel<UserOrdersModel>>> GetUserOrder(int id)
        {
            var userOrder = await _userOrderInterface.GetUserOrder(id);
            if (!userOrder.Status && userOrder.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = userOrder.Mensagem });
            }

            return Ok(userOrder);
        }

        // PUT: api/UserOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutUserOrders/{id}")]
        public async Task<ActionResult<ResponseModel<UserOrdersModel>>> PutUserOrders(int id, UserOrderRequest userOrderRequest)
        {
            var userOrder = await _userOrderInterface.PutUserOrders(id, userOrderRequest);
            if (!userOrder.Status && userOrder.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = userOrder.Mensagem });
            }

            return Ok(userOrder);
        }

        // POST: api/UserOrders
        [HttpPost("PostUserOrders")]
        public async Task<ActionResult<ResponseModel<UserOrdersModel>>> PostUserOrders(UserOrderRequest userOrderRequest)
        {
            var userOrder = await _userOrderInterface.PostUserOrders(userOrderRequest);
            if (!userOrder.Status && userOrder.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = userOrder.Mensagem });
            }

            return Ok(userOrder);
        }

        // DELETE: api/UserOrders/5
        [HttpDelete("DeleteUserOrders/{id}")]
        public async Task<ActionResult<ResponseModel<UserOrdersModel>>> DeleteUserOrders(int id)
        {
            var userOrder = await _userOrderInterface.DeleteUserOrders(id);
            if (!userOrder.Status && userOrder.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = userOrder.Mensagem });
            }

            return Ok(userOrder);
        }
    }
}