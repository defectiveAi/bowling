namespace BowlingConcept.Domain.Models.Bowling.Rules;

public sealed class SpareBowlingFrameRule : IFrameRule
{
    public bool CanKeepPlaying(IReadOnlyList<Roll> rolls)
    {
        return rolls.Count == 1 && rolls[0].ToppledPins < 10;
    }
}
