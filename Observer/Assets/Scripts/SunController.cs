using UnityEngine;
public class SunController : MonoBehaviour, IObserver
{
    [SerializeField] Transform centerPoint;
    [SerializeField] float orbitRadius = 8f;
    [SerializeField] float phaseOffset = -90f;
    IObservable _timeManager;

    void Awake() => _timeManager = FindFirstObjectByType<TimeManager>();
    void OnEnable() => _timeManager?.RegisterObserver(this);
    void OnDisable() => _timeManager?.RemoveObserver(this);

    public void OnNotify(float time01)
    {
        if (centerPoint == null) return;
        float angleDeg = (time01 * 360f) + phaseOffset;
        float angleRad = angleDeg * Mathf.Deg2Rad;
        Vector3 newPos = centerPoint.position;
        newPos.x += Mathf.Cos(angleRad) * orbitRadius;
        newPos.y += Mathf.Sin(angleRad) * orbitRadius;
        transform.position = newPos;
    }
}