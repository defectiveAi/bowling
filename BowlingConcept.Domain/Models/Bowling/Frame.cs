namespace BowlingConcept.Domain.Models.Bowling;

// Is Entity.
// Records the rolls of the player.
// Enforces rules of play, as rolls in a frame dictates game progress.
public sealed class Frame
{
    private readonly IReadOnlyList<IFrameRule> _rules;
    private readonly List<Roll> _rolls = [];

    public Frame(IReadOnlyList<IFrameRule> rules)
    {
        _rules = rules;
        Rolls = _rolls.AsReadOnly();
    }

    public IReadOnlyList<Roll> Rolls { get; }

    public bool IsFilledOut { get; private set; }

    public void RecordRoll(int toppledPins)
    {
        _rolls.Add(new Roll(toppledPins));
        ApplyRules();
    }

    private void ApplyRules()
    {
        if (_rules.Any(r => r.CanKeepPlaying(_rolls)))
            return;

        IsFilledOut = true;
    }
}
