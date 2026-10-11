using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] GameObject _prefabToSpawn;
    [SerializeField] Transform _playerCharacter;
    [SerializeField] int _maxHistorySize = 10;
    [SerializeField] InputListener _inputListener;

    Invoker _invoker;

    void Awake()
    {
        _invoker = new Invoker(_maxHistorySize);
        _inputListener.OnClick += HandleClick;
        _inputListener.OnEnterPressed += _invoker.ProcessPendingQueue;
        _inputListener.OnUndoPressed += _invoker.Undo;
    }

    void HandleClick(Vector2 pos, int buttonIndex)
    {
        if (buttonIndex == 0)
        {
            ICommand moveCmd = new Move(_playerCharacter);
            _invoker.ExecuteCommand(moveCmd, pos, isBuffered: false);
        }
        else if (buttonIndex == 1)
        {
            ICommand spawnCmd = new Spawn(_prefabToSpawn);
            _invoker.ExecuteCommand(spawnCmd, pos, isBuffered: true);
        }
    }

    void OnDestroy()
    {
        _inputListener.OnClick -= HandleClick;
        _inputListener.OnEnterPressed -= _invoker.ProcessPendingQueue;
        _inputListener.OnUndoPressed -= _invoker.Undo;
    }
}
