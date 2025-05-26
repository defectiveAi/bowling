using BowlingConcept.Domain.Models.Bowling.Rules;

namespace BowlingConcept.Domain.Models.Bowling;

// Is Entity.
// Sets up a game for a player: a set of frames the player must fill out with their rolls.
// Understands how the frames are played, but not the rolls.
public sealed class Scorecard
{
    public Scorecard()
    {
        IFrameRule[] regularRules = [new SpareBowlingFrameRule()];
        IFrameRule[] tenthFrameRules = [new SpareBowlingFrameRule(), new TenthBowlingFrameRule()];

        Frames =
        [
            ..Enumerable.Range(0, 9).Select(_ => new Frame(regularRules)),
            new Frame(tenthFrameRules),
        ];
    }

    public IReadOnlyList<Frame> Frames { get; }

    public bool IsFilledOut => Frames.All(f => f.IsFilledOut);

    public Frame CurrentFrame => Frames.First(f => !f.IsFilledOut);
}
