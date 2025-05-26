using BowlingConcept.Domain.Models;
using BowlingConcept.Domain.Models.Bowling;
using BowlingConcept.Domain.Repositories;

namespace BowlingConcept.Application;

public sealed class StartNewGameHandler
{
    private readonly IBowlingLaneRepository _bowlingLaneRepository;
    private readonly IBowlingGameRepository _bowlingGameRepository;

    public StartNewGameHandler(
        IBowlingLaneRepository bowlingLaneRepository,
        IBowlingGameRepository bowlingGameRepository)
    {
        _bowlingLaneRepository = bowlingLaneRepository;
        _bowlingGameRepository = bowlingGameRepository;
    }

    public void Command(Guid laneId, IReadOnlyList<string> playerNames)
    {
        var lane = _bowlingLaneRepository.Get(new BowlingLaneId(laneId));
        ClearLane(lane);

        var newGame = new BowlingGame();
        lane.Game = newGame.Id;

        foreach (var playerName in playerNames)
        {
            newGame.AddPlayer(new Player(playerName));
        }

        newGame.Start();

        _bowlingGameRepository.AddOrUpdate(newGame);
        _bowlingLaneRepository.AddOrUpdate(lane);
    }

    private void ClearLane(BowlingLane lane)
    {
        if (lane.Game != null)
        {
            _bowlingGameRepository.Delete(lane.Game);
        }
    }
}
