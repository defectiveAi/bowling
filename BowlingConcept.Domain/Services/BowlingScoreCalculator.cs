using BowlingConcept.Domain.Models.Bowling;

namespace BowlingConcept.Domain.Services;

public sealed class BowlingScoreCalculator
{
    public int CalculateScore(Scorecard scorecard)
    {
        var frames = scorecard.Frames;
        var total = 0;

        for (var i = 0; i < frames.Count; i++)
        {
            total += CalculateFrame(frames, i);
        }

        return total;
    }

    private static int CalculateFrame(IReadOnlyList<Frame> frames, int i)
    {
        var frame = frames[i];

        if (!frame.IsFilledOut)
            return 0;

        if (frame.Rolls[0].ToppledPins == 10)
        {
            return 10 + FindBonusRoll(frames, i, 1) + FindBonusRoll(frames, i, 2);
        }

        var sum = frame.Rolls.Sum(r => r.ToppledPins);
        if (sum == 10)
        {
            return 10 + FindBonusRoll(frames, i, 2);
        }

        return sum;
    }

    private static int FindBonusRoll(IReadOnlyList<Frame> frames, int i, int offset)
    {
        return frames
            .Skip(i)
            .SelectMany(f => f.Rolls)
            .Skip(offset)
            .Select(r => r.ToppledPins)
            .FirstOrDefault();
    }
}
