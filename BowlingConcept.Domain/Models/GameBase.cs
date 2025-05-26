namespace BowlingConcept.Domain.Models;

public abstract class GameBase
{
    private readonly List<Player> _players = [];

    protected GameBase()
    {
        Players = _players.AsReadOnly();
    }

    public bool HasStarted { get; private set; }
    public bool IsGameOver { get; private set; }

    public IReadOnlyList<Player> Players { get; }
    public abstract Player CurrentPlayer { get; }

    public virtual void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public virtual void Start()
    {
        HasStarted = true;
    }

    public virtual void End()
    {
        IsGameOver = true;
    }
}
