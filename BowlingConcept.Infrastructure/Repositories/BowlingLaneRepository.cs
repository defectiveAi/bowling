using BowlingConcept.Domain.Models.Bowling;
using BowlingConcept.Domain.Repositories;

namespace BowlingConcept.Infrastructure.Repositories;

public sealed class BowlingLaneRepository : IBowlingLaneRepository
{
    private readonly Dictionary<BowlingLaneId, BowlingLane> _storage = [];

    public BowlingLaneRepository(int mockedLanes)
    {
        _storage = Enumerable
            .Range(0, mockedLanes)
            .Select(_ => new BowlingLane(new BowlingLaneId()))
            .ToDictionary(lane => lane.Id);
    }

    public IEnumerable<BowlingLane> Get()
    {
        return _storage.Values;
    }

    public BowlingLane Get(BowlingLaneId bowlingLaneId)
    {
        if (_storage.TryGetValue(bowlingLaneId, out var bowlingLane))
        {
            return bowlingLane;
        }

        throw new InvalidOperationException();
    }

    public void AddOrUpdate(BowlingLane bowlingLane)
    {
        _storage[bowlingLane.Id] = bowlingLane;
    }
}
