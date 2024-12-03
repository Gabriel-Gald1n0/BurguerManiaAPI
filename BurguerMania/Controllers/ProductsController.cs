using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Context;
using BurguerManiaAPI.Models;
using BurguerManiaAPI.Dto.Product;
using BurguerManiaAPI.Interfaces.Product;


namespace BurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductInterface _productInterface;

        public ProductsController(IProductInterface productInterface)
        {
            _productInterface = productInterface;
        }

        // GET: api/Products
        [HttpGet("GetProducts")]
        public async Task<ActionResult<ResponseModel<List<ProductResponse>>>> GetProducts()
        {
            var products = await _productInterface.GetProducts();
            if (!products.Status && products.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = products.Mensagem });
            }

            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("GetProduct/{id}")]
        public async Task<ActionResult<ResponseModel<ProductResponse>>> GetProduct(int id)
        {
            var product = await _productInterface.GetProduct(id);
            if (!product.Status && product.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = product.Mensagem });
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutProducts/{id}")]
        public async Task<ActionResult<ResponseModel<ProductResponse>>> PutProducts(int id, ProductRequest productRequest)
        {
            var product = await _productInterface.PutProducts(id, productRequest);
            if (!product.Status && product.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = product.Mensagem });
            }

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost("PostProducts")]
        public async Task<ActionResult<ResponseModel<ProductResponse>>> PostProducts(ProductRequest productRequest)
        {
            var product = await _productInterface.PostProducts(productRequest);
            if (!product.Status && product.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = product.Mensagem });
            }

            return Ok(product);
        }

        // DELETE: api/Products/5
        [HttpDelete("delete/product/{id}")]
        public async Task<ActionResult<ResponseModel<ProductResponse>>> DeleteProducts(int id)
        {
            var product = await _productInterface.DeleteProducts(id);
            if (!product.Status && product.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = product.Mensagem });
            }

            return Ok(product);
        }

    }
}
