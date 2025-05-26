namespace BowlingConcept.Domain.Models.Bowling;

public sealed record BowlingGameId(Guid Value)
{
    public BowlingGameId() : this(Guid.NewGuid())
    {
    }
}
