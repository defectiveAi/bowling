using BowlingConcept.Application.Models;
using BowlingConcept.Domain.Models.Bowling;
using BowlingConcept.Domain.Repositories;
using BowlingConcept.Domain.Services;
using BowlingConcept.Infrastructure.Repositories;

namespace BowlingConcept.Application;

public sealed class GetScoreboardHandler
{
    private readonly IBowlingLaneRepository _bowlingLaneRepository;
    private readonly IBowlingGameRepository _bowlingGameRepository;
    private readonly BowlingScoreCalculator _bowlingScoreCalculator;

    public GetScoreboardHandler(
        IBowlingLaneRepository bowlingLaneRepository,
        IBowlingGameRepository bowlingGameRepository,
        BowlingScoreCalculator bowlingScoreCalculator)
    {
        _bowlingLaneRepository = bowlingLaneRepository;
        _bowlingGameRepository = bowlingGameRepository;
        _bowlingScoreCalculator = bowlingScoreCalculator;
    }

    public ScoreboardDto Query(Guid bowlingLaneId)
    {
        var lane = _bowlingLaneRepository.Get(new BowlingLaneId(bowlingLaneId));
        if (lane.Game == null)
            return new ScoreboardDto();

        var game = _bowlingGameRepository.Get(lane.Game);
        if (game == null)
            return new ScoreboardDto();

        var scorecards = game.Scorecards.Select(kv =>
        {
            var player = kv.Key;
            var card = kv.Value;

            var score = _bowlingScoreCalculator.CalculateScore(card);

            var frames = card.Frames.Select(frame => new FrameDto
            {
                Rolls = [.. frame.Rolls.Select(r => r.ToppledPins)]
            });

            return new ScorecardDto
            {
                PlayerName = player.Name,
                Score = score,
                Frames = [.. frames]
            };
        });

        return new ScoreboardDto { Scorecards = [.. scorecards] };
    }
}
