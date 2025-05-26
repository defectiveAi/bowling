using BowlingConcept.Domain.Models.Bowling;

namespace BowlingConcept.Domain.Repositories;

public interface IBowlingLaneRepository
{
    IEnumerable<BowlingLane> Get();
    BowlingLane Get(BowlingLaneId bowlingLaneId);

    void AddOrUpdate(BowlingLane bowlingLane);
}
