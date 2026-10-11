using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    public Action<Vector2, int> OnClick;
    public Action OnEnterPressed;
    public Action OnUndoPressed;

    void Update()
    {
        if (Mouse.current == null || Keyboard.current == null) return;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        if (Mouse.current.leftButton.wasPressedThisFrame) OnClick?.Invoke(mousePos, 0);
        if (Mouse.current.rightButton.wasPressedThisFrame) OnClick?.Invoke(mousePos, 1);
        if (Mouse.current.middleButton.wasPressedThisFrame) OnUndoPressed?.Invoke();
        if (Keyboard.current.enterKey.wasPressedThisFrame) OnEnterPressed?.Invoke();
    }
}
