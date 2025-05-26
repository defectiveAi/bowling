namespace BowlingConcept.Domain.Models;

public sealed class Player(string name)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } = name;
}
