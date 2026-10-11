using UnityEngine;
public interface ICommand
{
    void Execute(Vector2 position);
    void Undo();
}