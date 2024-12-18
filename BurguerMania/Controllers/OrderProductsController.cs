using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Context;
using BurguerManiaAPI.Models;
using BurguerManiaAPI.Dto.OrderProduct;
using BurguerManiaAPI.Interfaces.OrderProduct;

namespace BurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductsController : ControllerBase
    {
        private readonly IOrderProductInterface _orderProductInterface;

        public OrderProductsController(IOrderProductInterface orderProductInterface)
        {
            _orderProductInterface = orderProductInterface;
        }

        // GET: api/OrderProducts
        [HttpGet("GetOrderProducts")]
        public async Task<ActionResult<ResponseModel<List<OrderProductResponse>>>> GetOrderProducts()
        {
            var orderProducts = await _orderProductInterface.GetOrderProducts();
            if (!orderProducts.Status)
            {
                 return StatusCode(orderProducts.StatusCode, new { status = orderProducts.StatusCode, erros = orderProducts.Mensagem });
            }

            return Ok(orderProducts);
        }

        // GET: api/OrderProducts/5
        [HttpGet("GetOrderProduct/{id}")]
        public async Task<ActionResult<ResponseModel<OrderProductResponse>>> GetOrderProduct(int id)
        {
            var orderProduct = await _orderProductInterface.GetOrderProduct(id);
            if (!orderProduct.Status)
            {
                 return StatusCode(orderProduct.StatusCode, new { status = orderProduct.StatusCode, erros = orderProduct.Mensagem });
            }

            return Ok(orderProduct);
        }

        // PUT: api/OrderProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutOrderProducts/{id}")]
        public async Task<ActionResult<ResponseModel<OrderProductResponse>>> PutOrderProducts(int id, OrderProductRequest orderProductRequest)
        {
            if (!ModelState.IsValid)
            {
                // Caso o modelo não seja válido, retorna uma resposta com as mensagens de erro
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { erros = errorMessages });
            }
            
            var orderProduct = await _orderProductInterface.PutOrderProducts(id, orderProductRequest);
            
            if (!orderProduct.Status)
            {
                return StatusCode(orderProduct.StatusCode, new { status = orderProduct.StatusCode, erros = orderProduct.Mensagem });
            }
            return Ok(orderProduct);
        }

        // POST: api/OrderProducts
        [HttpPost("PostOrderProducts")]
        public async Task<ActionResult<ResponseModel<OrderProductResponse>>> PostOrderProducts(OrderProductRequest orderProductRequest)
        {
            if (!ModelState.IsValid)
            {
                // Caso o modelo não seja válido, retorna uma resposta com as mensagens de erro
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { erros = errorMessages });
            }
            
            var orderProduct = await _orderProductInterface.PostOrderProducts(orderProductRequest);
            
            if (!orderProduct.Status)
            {
                return StatusCode(orderProduct.StatusCode, new { status = orderProduct.StatusCode, erros = orderProduct.Mensagem });
            }

            return Ok(orderProduct);
        }

        // DELETE: api/OrderProducts/5
        [HttpDelete("DeleteOrderProducts/{id}")]
        public async Task<ActionResult<ResponseModel<OrderProductResponse>>> DeleteOrderProducts(int id)
        {
            var orderProduct = await _orderProductInterface.DeleteOrderProducts(id);
            if (!orderProduct.Status)
            {
                return StatusCode(orderProduct.StatusCode, new { status = orderProduct.StatusCode, erros = orderProduct.Mensagem });
            }

            return Ok(orderProduct);
        }
    }
}
