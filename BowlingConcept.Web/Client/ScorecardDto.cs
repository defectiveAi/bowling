namespace BowlingConcept.Web.Client;

public sealed class ScorecardDto
{
    public string PlayerName { get; set; } = string.Empty;
    public FrameDto[] Frames { get; set; } = [];
    public int Score { get; set; }
}
