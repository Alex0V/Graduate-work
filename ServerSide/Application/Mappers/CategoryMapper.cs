using Application.DTO.Category.Requests;
using Application.DTO.Category.Responses;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mappers;

[Mapper]
public partial class CategoryMapper
{
    public partial List<CategoryResponseDto> CategoryToCategoryResponseDto(List<Category> category);
    public partial Category CategoryRequestDtoToCategory(CategoryRequestDto categoryRequestDto);
}
