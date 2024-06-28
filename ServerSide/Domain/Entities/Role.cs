using Domain.Primitives;

namespace Domain.Entities;

public sealed class Role : Entity
{
    public string? UserRole {  get; set; }
}
