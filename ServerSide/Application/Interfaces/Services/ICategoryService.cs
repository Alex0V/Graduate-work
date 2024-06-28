using Application.DTO.Category.Requests;
using Application.DTO.Category.Responses;
using ErrorOr;

namespace Application.Interfaces.Services;

public interface ICategoryService
{
    Task<ErrorOr<List<CategoryResponseDto>>> GetAllCategoriesAsync();
    Task<ErrorOr<Deleted>> DeleteCategoryAsync(int id);
    Task<ErrorOr<Created>> AddCategoryAsync(CategoryRequestDto categoryRequestDto);
}
