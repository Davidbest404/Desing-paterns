using UnityEngine;

public class Spawn : ICommand
{
    GameObject _prefab;
    GameObject _spawnedInstance;

    public Spawn(GameObject prefab) => _prefab = prefab;

    public void Execute(Vector2 position) => _spawnedInstance = Object.Instantiate(_prefab, position, Quaternion.identity);

    public void Undo()
    {
        if (_spawnedInstance != null) Object.Destroy(_spawnedInstance);
    }
}
