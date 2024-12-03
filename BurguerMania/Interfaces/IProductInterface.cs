using BurguerManiaAPI.Dto.Product;
using BurguerManiaAPI.Models;

namespace BurguerManiaAPI.Interfaces.Product
{
    public interface IProductInterface
    {
        Task<ResponseModel<List<ProductResponse>>> GetProducts();
        Task<ResponseModel<ProductResponse>> GetProduct(int id);
        Task<ResponseModel<ProductResponse>> PostProducts(ProductRequest productRequest);
        Task<ResponseModel<ProductResponse>> PutProducts(int id, ProductRequest productRequest);
        Task<ResponseModel<ProductResponse>> DeleteProducts(int id);
    }
}