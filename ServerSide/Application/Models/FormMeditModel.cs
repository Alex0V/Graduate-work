using Microsoft.AspNetCore.Http;

namespace Application.Models;

public class FormMeditModel
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public IFormFile image { get; set; } = null!;
}
