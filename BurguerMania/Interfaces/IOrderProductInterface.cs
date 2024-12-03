using BurguerManiaAPI.Dto.OrderProduct;
using BurguerManiaAPI.Models;

namespace BurguerManiaAPI.Interfaces.OrderProduct
{
    public interface IOrderProductInterface
    {
        Task<ResponseModel<List<OrderProductResponse>>> GetOrderProducts();
        Task<ResponseModel<OrderProductResponse>> GetOrderProduct(int id);
        Task<ResponseModel<OrderProductResponse>> PostOrderProducts(OrderProductRequest orderProductRequest);
        Task<ResponseModel<OrderProductResponse>> PutOrderProducts(int id, OrderProductRequest orderProductRequest);
        Task<ResponseModel<OrderProductResponse>> DeleteOrderProducts(int id);
    }
}