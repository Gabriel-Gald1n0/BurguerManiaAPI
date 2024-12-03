using BurguerManiaAPI.Dto.User;
using BurguerManiaAPI.Models;


namespace BurguerManiaAPI.Interfaces.User
{
    public interface IUserInterface
    {
        Task<ResponseModel<List<UsersModel>>> GetUsers();
        Task<ResponseModel<UsersModel>> GetUser(int id);
        Task<ResponseModel<UsersModel>> PostUsers(UserRequest UserRequest);
        Task<ResponseModel<UserResponse>> PutUsers(int id, UserRequest UserRequest);
        Task<ResponseModel<UserResponse>> DeleteUsers(int id);
    }
}