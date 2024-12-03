using BurguerManiaAPI.Dto.UserOrder;
using BurguerManiaAPI.Models;

namespace BurguerManiaAPI.Interfaces.UserOrder
{
    public interface IUserOrderInterface
    {
        Task<ResponseModel<List<UserOrdersModel>>> GetUserOrders();
        Task<ResponseModel<UserOrdersModel>> GetUserOrder(int id);
        Task<ResponseModel<UserOrdersModel>> PostUserOrders(UserOrderRequest UserOrderRequest);
        Task<ResponseModel<UserOrderResponse>> PutUserOrders(int id, UserOrderRequest UserOrderRequest);
        Task<ResponseModel<UserOrderResponse>> DeleteUserOrders(int id);
    }
}