using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerContext _context;
    public void Init(PlayerContext context) => _context = context;
    public void Tick()
    {
        if (_context == null) return;
        transform.Translate(_context.MoveDirection * (_context.Speed * Time.deltaTime));
    }
}
