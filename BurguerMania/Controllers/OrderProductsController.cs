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
            if (!orderProducts.Status && orderProducts.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = orderProducts.Mensagem });
            }

            return Ok(orderProducts);
        }

        // GET: api/OrderProducts/5
        [HttpGet("GetOrderProduct/{id}")]
        public async Task<ActionResult<ResponseModel<OrderProductResponse>>> GetOrderProduct(int id)
        {
            var orderProduct = await _orderProductInterface.GetOrderProduct(id);
            if (!orderProduct.Status && orderProduct.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = orderProduct.Mensagem });
            }

            return Ok(orderProduct);
        }

        // PUT: api/OrderProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutOrderProducts/{id}")]
        public async Task<ActionResult<ResponseModel<OrderProductResponse>>> PutOrderProducts(int id, OrderProductRequest orderProductRequest)
        {
            var orderProduct = await _orderProductInterface.PutOrderProducts(id, orderProductRequest);
            if (!orderProduct.Status && orderProduct.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = orderProduct.Mensagem });
            }

            return Ok(orderProduct);
        }

        // POST: api/OrderProducts
        [HttpPost("PostOrderProducts")]
        public async Task<ActionResult<ResponseModel<OrderProductResponse>>> PostOrderProducts(OrderProductRequest orderProductRequest)
        {
            var orderProduct = await _orderProductInterface.PostOrderProducts(orderProductRequest);
            if (!orderProduct.Status && orderProduct.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = orderProduct.Mensagem });
            }

            return Ok(orderProduct);
        }

        // DELETE: api/OrderProducts/5
        [HttpDelete("DeleteOrderProducts/{id}")]
        public async Task<ActionResult<ResponseModel<OrderProductResponse>>> DeleteOrderProducts(int id)
        {
            var orderProduct = await _orderProductInterface.DeleteOrderProducts(id);
            if (!orderProduct.Status && orderProduct.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = orderProduct.Mensagem });
            }

            return Ok(orderProduct);
        }
    }
}
