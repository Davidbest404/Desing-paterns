using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    readonly int _maxHistorySize;
    readonly List<ICommand> _commandHistory = new List<ICommand>();
    readonly Queue<(ICommand cmd, Vector2 pos)> _pendingBuffer = new Queue<(ICommand, Vector2)>();

    public Invoker(int maxHistorySize) => _maxHistorySize = maxHistorySize;

    public void ExecuteCommand(ICommand command, Vector2 position, bool isBuffered)
    {
        if (isBuffered)
        {
            _pendingBuffer.Enqueue((command, position));
            Debug.Log("команда добавлена в очередь выполнения");
        }
        else
        {
            command.Execute(position);
            AddToHistory(command);
        }
    }

    public void ProcessPendingQueue()
    {
        while (_pendingBuffer.Count > 0)
        {
            var item = _pendingBuffer.Dequeue();
            item.cmd.Execute(item.pos);
            AddToHistory(item.cmd); 
        }
    }

    void AddToHistory(ICommand command)
    {
        _commandHistory.Add(command);
        if (_commandHistory.Count > _maxHistorySize) _commandHistory.RemoveAt(0);
    }

    public void Undo()
    {
        if (_commandHistory.Count > 0)
        {
            int lastIndex = _commandHistory.Count - 1;
            _commandHistory[lastIndex].Undo();
            _commandHistory.RemoveAt(lastIndex);
        }
    }
}
