namespace BowlingConcept.Domain.Models.Bowling;

public sealed record BowlingLaneId(Guid Value)
{
    public BowlingLaneId() : this(Guid.NewGuid())
    {
    }
}
