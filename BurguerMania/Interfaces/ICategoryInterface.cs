using BurguerManiaAPI.Dto.Category;
using BurguerManiaAPI.Models;

namespace BurguerManiaAPI.Interfaces.Category
{
    public interface ICategoryInterface
    {
        Task<ResponseModel<List<CategoryResponse>>> GetCategories();
        Task<ResponseModel<CategoryResponse>> GetCategory(int id);
        Task<ResponseModel<CategoryResponse>> PostCategories(CategoryRequest categoryRequest);
        Task<ResponseModel<CategoryResponse>> PutCategories(int id, CategoryRequest categoryRequest);
        Task<ResponseModel<CategoryResponse>> DeleteCategories(int id);
    }
}