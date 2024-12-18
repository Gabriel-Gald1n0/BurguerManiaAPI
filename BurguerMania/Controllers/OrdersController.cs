using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Context;
using BurguerManiaAPI.Models;
using BurguerManiaAPI.Dto.Order;
using BurguerManiaAPI.Interfaces.Order;

namespace BurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderInterface _orderInterface;

        public OrdersController(IOrderInterface orderInterface)
        {
            _orderInterface = orderInterface;
        }

        // GET: api/Orders
        [HttpGet("GetOrders")]
        public async Task<ActionResult<ResponseModel<List<OrderResponse>>>> GetOrders()
        {
            var orders = await _orderInterface.GetOrders();
            if (!orders.Status)
            {
                return StatusCode(orders.StatusCode, new { status = orders.StatusCode, erros = orders.Mensagem });
            }

            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("GetOrder/{id}")]
        public async Task<ActionResult<ResponseModel<OrderResponse>>> GetOrder(int id)
        {
            var order = await _orderInterface.GetOrder(id);
            if (!order.Status)
            {
                return StatusCode(order.StatusCode, new { status = order.StatusCode, erros = order.Mensagem });
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutOrders/{id}")]
        public async Task<ActionResult<ResponseModel<OrderResponse>>> PutOrders(int id, OrderRequest orderRequest)
        {
            if (!ModelState.IsValid)
            {
                // Caso o modelo não seja válido, retorna uma resposta com as mensagens de erro
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { erros = errorMessages });
            }
            
            var order = await _orderInterface.PutOrders(id, orderRequest);
            
            if (!order.Status)
            {
                return StatusCode(order.StatusCode, new { status = order.StatusCode, erros = order.Mensagem });
            }
            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost("PostOrders")]
        public async Task<ActionResult<ResponseModel<OrderResponse>>> PostOrders(OrderRequest orderRequest)
        {
            if (!ModelState.IsValid)
            {
                // Caso o modelo não seja válido, retorna uma resposta com as mensagens de erro
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { erros = errorMessages });
            }

            var order = await _orderInterface.PostOrders(orderRequest);
            
            if (!order.Status)
            {
                return StatusCode(order.StatusCode, new { status = order.StatusCode, erros = order.Mensagem });
            }
            return Ok(order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("DeleteOrders/{id}")]
        public async Task<ActionResult<ResponseModel<OrderResponse>>> DeleteOrders(int id)
        {
            var order = await _orderInterface.DeleteOrders(id);
            if (!order.Status)
            {
                return StatusCode(order.StatusCode, new { status = order.StatusCode, erros = order.Mensagem });
            }

            return Ok(order);
        }
    }
}
