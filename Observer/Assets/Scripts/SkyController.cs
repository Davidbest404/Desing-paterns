using UnityEngine;
public class SkyController : MonoBehaviour, IObserver
{
    [SerializeField] Gradient skyGradient;
    [SerializeField] Camera _cam;
    IObservable _timeManager;
    
    void Awake() => _timeManager = FindFirstObjectByType<TimeManager>();
    void OnEnable() => _timeManager?.RegisterObserver(this);
    void OnDisable() => _timeManager?.RemoveObserver(this);
    public void OnNotify(float time01) => _cam.backgroundColor = skyGradient.Evaluate(time01);
}