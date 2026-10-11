using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed = 15f;
    [SerializeField] float LifeTime = 3f;
    void Start() => Destroy(gameObject, LifeTime);
    void Update() => transform.Translate(Vector3.right * (Speed * Time.deltaTime));
}