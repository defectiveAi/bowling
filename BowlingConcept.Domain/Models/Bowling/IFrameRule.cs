namespace BowlingConcept.Domain.Models.Bowling;

public interface IFrameRule
{
    bool CanKeepPlaying(IReadOnlyList<Roll> rolls);
}
