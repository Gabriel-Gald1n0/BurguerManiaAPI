using BurguerManiaAPI.Dto.Order;
using BurguerManiaAPI.Models;

namespace BurguerManiaAPI.Interfaces.Order
{
    public interface IOrderInterface
    {
        Task<ResponseModel<List<OrderResponse>>> GetOrders();
        Task<ResponseModel<OrderResponse>> GetOrder(int id);
        Task<ResponseModel<OrderResponse>> PostOrders(OrderRequest orderRequest);
        Task<ResponseModel<OrderResponse>> PutOrders(int id, OrderRequest orderRequest);
        Task<ResponseModel<OrderResponse>> DeleteOrders(int id);
    }
}