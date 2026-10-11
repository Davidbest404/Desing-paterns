using UnityEngine;

public class PlayerShootState : BaseState
{
    readonly PlayerContext _context;
    readonly InputReader _input;

    public PlayerShootState(PlayerContext context, InputReader input)
    {
        _context = context;
        _input = input;
    }

    public override void Enter() => _input.OnAttack += Shoot;
    public override void Exit() => _input.OnAttack -= Shoot;

    void Shoot() => GameObject.Instantiate(_context.BulletPrefab, _context.FirePoint.position, Quaternion.identity);
}

public class PlayerAoEState : BaseState
{
    readonly PlayerContext _context;
    readonly InputReader _input;

    public PlayerAoEState(PlayerContext context, InputReader input)
    {
        _context = context;
        _input = input;
    }

    public override void Enter() => _input.OnAttack += ToggleAoE;
    public override void Exit()
    {
        _input.OnAttack -= ToggleAoE;
        _context.Circle.SetActive(false);
    }

    void ToggleAoE() => _context.Circle.SetActive(!_context.Circle.activeSelf);
}

public class PlayerGhostState : BaseState
{
    readonly PlayerContext _context;
    readonly InputReader _input;
    bool _isGhost;

    public PlayerGhostState(PlayerContext context, InputReader input)
    {
        _context = context;
        _input = input;
    }

    public override void Enter() => _input.OnAttack += ToggleGhost;
    public override void Exit()
    {
        _input.OnAttack -= ToggleGhost;
        SetAlpha(1f);
    }

    void ToggleGhost()
    {
        _isGhost = !_isGhost;
        SetAlpha(_isGhost ? 0.5f : 1f);
    }

    void SetAlpha(float alpha)
    {
        var color = _context.SpriteRenderer.color;
        color.a = alpha;
        _context.SpriteRenderer.color = color;
    }
}