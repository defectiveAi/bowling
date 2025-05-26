namespace BowlingConcept.Domain.Models.Bowling;

public sealed class Roll(int toppledPins)
{
    public int ToppledPins { get; } = toppledPins;
}
