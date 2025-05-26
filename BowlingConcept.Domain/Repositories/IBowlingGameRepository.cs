using BowlingConcept.Domain.Models.Bowling;

namespace BowlingConcept.Domain.Repositories;

public interface IBowlingGameRepository
{
    BowlingGame? Get(BowlingGameId bowlingGameId);

    void AddOrUpdate(BowlingGame bowlingGame);

    void Delete(BowlingGameId bowlingGameId);
}
