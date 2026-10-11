using UnityEngine;

public class GameState : BaseState
{
    private readonly InputReader _input;

    public GameState(InputReader input) => _input = input;

    public override void Enter()
    {
        Time.timeScale = 1f;
        _input.EnableGameInput();
    }

    public override void Exit() => _input.DisableGameInput();
}

public class PauseState : BaseState
{
    public override void Enter() => Time.timeScale = 0f;
    public override void Exit() => Time.timeScale = 1f;
}

public class FinalState : BaseState
{
    readonly PlayerContext _player;
    readonly PlayerMovement _movement;

    public FinalState(PlayerContext player, PlayerMovement movement)
    {
        _player = player;
        _movement = movement;
    }

    public override void Enter()
    {
        Time.timeScale = 1f;
        _player.SpriteRenderer.color = Color.green; 
        _movement.enabled = false;
        _player.Circle.SetActive(false);
    }
}
