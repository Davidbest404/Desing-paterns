using UnityEngine;

public class PlayerContext : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public GameObject Circle;
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public float Speed = 5f;
    
    [HideInInspector] public Vector2 MoveDirection;
}