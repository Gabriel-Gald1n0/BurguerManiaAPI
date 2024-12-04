using BurguerManiaAPI.Dto.UserOrder;
using BurguerManiaAPI.Models;

namespace BurguerManiaAPI.Interfaces.UserOrder
{
    public interface IUserOrderInterface
    {
        Task<ResponseModel<List<UserOrderResponse>>> GetUserOrders();
        Task<ResponseModel<UserOrderResponse>> GetUserOrder(int id);
        Task<ResponseModel<UserOrderResponse>> PostUserOrders(UserOrderRequest UserOrderRequest);
        Task<ResponseModel<UserOrderResponse>> PutUserOrders(int id, UserOrderRequest UserOrderRequest);
        Task<ResponseModel<UserOrderResponse>> DeleteUserOrders(int id);
    }
}