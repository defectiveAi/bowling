namespace BowlingConcept.Domain.Models.Bowling;

public sealed class BowlingLane(BowlingLaneId id)
{
    public BowlingLaneId Id { get; set; } = id;
    
    public BowlingGameId? Game { get; set; }
}
