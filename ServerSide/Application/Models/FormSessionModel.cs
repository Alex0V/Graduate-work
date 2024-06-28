using Microsoft.AspNetCore.Http;

namespace Application.Models;

public class FormSessionModel
{
    public string Name { get; set; } = null!;

    public IFormFile image { get; set; } = null!;
}
