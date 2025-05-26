using BowlingConcept.Domain.Models.Bowling;
using BowlingConcept.Domain.Repositories;

namespace BowlingConcept.Infrastructure.Repositories;

public sealed class BowlingGameRepository : IBowlingGameRepository
{
    private readonly Dictionary<BowlingGameId, BowlingGame> _storage = [];

    public BowlingGame? Get(BowlingGameId bowlingGameId)
    {
        if (_storage.TryGetValue(bowlingGameId, out var bowlingGame))
        {
            return bowlingGame;
        }

        return null;
    }

    public void AddOrUpdate(BowlingGame bowlingGame)
    {
        _storage[bowlingGame.Id] = bowlingGame;
    }

    public void Delete(BowlingGameId bowlingGameId)
    {
        _storage.Remove(bowlingGameId);
    }
}
