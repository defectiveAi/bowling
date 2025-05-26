namespace BowlingConcept.Domain.Models.Bowling;

// Is AggregateRoot.
// Keeps track of the players (through GameBase) and the game's lifecycle.
// Gives the players scorecards to fill out, but does not focus on game rules.
public sealed class BowlingGame : GameBase
{
    private readonly Dictionary<Player, Scorecard> _scorecards = [];

    private Player? _currentPlayer;

    public BowlingGame()
    {
        Id = new();
        Scorecards = _scorecards.AsReadOnly();
    }

    public BowlingGameId Id { get; }

    public IReadOnlyDictionary<Player, Scorecard> Scorecards { get; }

    public override Player CurrentPlayer => _currentPlayer ?? throw new InvalidOperationException();

    public override void Start()
    {
        foreach (var player in Players)
        {
            _scorecards.Add(player, new Scorecard());
        }

        GoToNextPlayer();
        base.Start();
    }

    public void TopplePins(int toppledPins)
    {
        var currentFrame = Scorecards[CurrentPlayer].CurrentFrame;
        currentFrame.RecordRoll(toppledPins);

        if (currentFrame.IsFilledOut)
            GoToNextPlayer();
    }

    private void GoToNextPlayer()
    {
        var currentIndex = 0;

        foreach (var player in Players)
        {
            if (player == _currentPlayer)
                break;

            currentIndex++;
        }

        var nextIndex = currentIndex + 1;
        if (nextIndex >= Players.Count)
            nextIndex = 0;

        _currentPlayer = Players[nextIndex];

        if (!CanGameContinue())
            End();
    }

    private bool CanGameContinue()
    {
        return _currentPlayer != null && !Scorecards[_currentPlayer].IsFilledOut;
    }
}
