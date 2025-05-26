using BowlingConcept.Domain.Repositories;

namespace BowlingConcept.Application;

public sealed class GetBowlingLanesHandler
{
    private readonly IBowlingLaneRepository _bowlingLaneRepository;

    public GetBowlingLanesHandler(IBowlingLaneRepository bowlingLaneRepository)
    {
        _bowlingLaneRepository = bowlingLaneRepository;
    }

    public IEnumerable<Guid> Query()
    {
        return _bowlingLaneRepository.Get().Select(l => l.Id.Value);
    }
}
