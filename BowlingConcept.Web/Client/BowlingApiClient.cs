namespace BowlingConcept.Web.Client;

public class BowlingApiClient(HttpClient httpClient)
{
    public async Task<Guid[]> GetBowlingLanesAsync(CancellationToken cancellationToken = default)
    {
        var lanes = await httpClient.GetFromJsonAsync<Guid[]>("/lane", cancellationToken);
        return lanes ?? [];
    }

    public async Task<ScoreboardDto> GetScoreboardAsync(Guid laneId, CancellationToken cancellationToken = default)
    {
        var scoreboard = await httpClient.GetFromJsonAsync<ScoreboardDto>($"/lane/{laneId}/score", cancellationToken);
        return scoreboard ?? new();
    }

    public Task StartNewGameAsync(Guid laneId, IEnumerable<string> playerNames, CancellationToken cancellationToken = default)
    {
        return httpClient.PostAsJsonAsync($"/lane/{laneId}", playerNames, cancellationToken);
    }

    public Task ToppleBowlingPinsAsync(Guid laneId, int toppledPins, CancellationToken cancellationToken = default)
    {
        return httpClient.PostAsync($"/lane/{laneId}/topple?toppledPins={toppledPins}", null, cancellationToken);
    }
}
