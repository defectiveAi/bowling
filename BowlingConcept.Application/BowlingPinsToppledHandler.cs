using BowlingConcept.Domain.Models.Bowling;
using BowlingConcept.Domain.Repositories;

namespace BowlingConcept.Application;

public sealed class BowlingPinsToppledHandler
{
    private readonly IBowlingLaneRepository _bowlingLaneRepository;
    private readonly IBowlingGameRepository _bowlingGameRepository;

    public BowlingPinsToppledHandler(
        IBowlingLaneRepository bowlingLaneRepository,
        IBowlingGameRepository bowlingGameRepository)
    {
        _bowlingLaneRepository = bowlingLaneRepository;
        _bowlingGameRepository = bowlingGameRepository;
    }

    public void Command(Guid laneId, int toppledPins)
    {
        var lane = _bowlingLaneRepository.Get(new BowlingLaneId(laneId));
        if (lane.Game == null)
            return;

        var game = _bowlingGameRepository.Get(lane.Game);
        if (game == null || game.IsGameOver)
            return;

        game.TopplePins(toppledPins);

        _bowlingGameRepository.AddOrUpdate(game);
    }
}
