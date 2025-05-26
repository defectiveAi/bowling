namespace BowlingConcept.Domain.Models.Bowling.Rules;

public sealed class TenthBowlingFrameRule : IFrameRule
{
    public bool CanKeepPlaying(IReadOnlyList<Roll> rolls)
    {
        return rolls.Count < 3 && rolls.Select(r => r.ToppledPins).Sum() >= 10; // Only get a third roll if strike or spare.
    }
}
