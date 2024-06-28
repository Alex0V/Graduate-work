using Application.DTO.Category.Requests;
using Application.DTO.Category.Responses;
using Application.Interfaces.Services;
using Application.Mappers;
using Domain.Interfaces.Repositories;
using ErrorOr;

namespace Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryMapper _categoryMapper;

    public CategoryService(ICategoryRepository categoryRepository, CategoryMapper categoryMapper)
    {
        _categoryRepository = categoryRepository;
        _categoryMapper = categoryMapper;
    }

    public async Task<ErrorOr<List<CategoryResponseDto>>> GetAllCategoriesAsync()
    {
        var allCategories = await _categoryRepository.GetAllAsync();
        if (!allCategories.Any())
        {
            return Error.NotFound(description: "Categories not found");
        }

        return _categoryMapper.CategoryToCategoryResponseDto(allCategories);
    }

    public async Task<ErrorOr<Deleted>> DeleteCategoryAsync(int id)
    {
        await _categoryRepository.DeleteByIdAsync(id);

        return Result.Deleted;
    }

    public async Task<ErrorOr<Created>> AddCategoryAsync(CategoryRequestDto categoryRequestDto)
    {
        var category = _categoryMapper.CategoryRequestDtoToCategory(categoryRequestDto);
        await _categoryRepository.AddAsync(category);

        return Result.Created;
    }
}
