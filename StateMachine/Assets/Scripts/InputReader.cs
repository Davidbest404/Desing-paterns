using System;
using UnityEngine;

public class InputReader
{
    public event Action<Vector2> OnMove;
    public event Action OnAttack;
    public event Action OnSwitchPlayerState;
    public event Action OnTogglePause;
    public event Action OnFinalState;
    PlayerControls _controls;

    public InputReader()
    {
        _controls = new PlayerControls();

        _controls.Player.Move.performed += ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>());
        _controls.Player.Move.canceled += _ => OnMove?.Invoke(Vector2.zero);
        _controls.Player.Attack.started += _ => OnAttack?.Invoke();
        _controls.Player.SwitchPlayerState.started += _ => OnSwitchPlayerState?.Invoke();

        _controls.System.TogglePause.started += _ => OnTogglePause?.Invoke();
        _controls.System.FinalState.started += _ => OnFinalState?.Invoke();
        _controls.System.Enable();
    }

    public void EnableGameInput() => _controls.Player.Enable();
    public void DisableGameInput() => _controls.Player.Disable();
}
