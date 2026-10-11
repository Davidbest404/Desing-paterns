public class Move : ICommand
{
    Transform _playerTransform;
    Vector2 _previousPosition;
    Vector2 _targetPosition;

    public Move(Transform player) => _playerTransform = player;

    public void Execute(Vector2 position)
    {
        _previousPosition = _playerTransform.position;
        _targetPosition = position;
        _playerTransform.position = position;
    }

    public void Undo() => _playerTransform.position = _previousPosition;
}
