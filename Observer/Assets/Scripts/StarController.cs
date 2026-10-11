using UnityEngine;
public class StarController : MonoBehaviour, IObserver
{
    [SerializeField] AnimationCurve alphaCurve;
    SpriteRenderer _spriteRenderer;
    IObservable _timeManager;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _timeManager = FindFirstObjectByType<TimeManager>();
    }

    void OnEnable() => _timeManager?.RegisterObserver(this);
    void OnDisable() => _timeManager?.RemoveObserver(this);

    public void OnNotify(float time01)
    {
        float currentAlpha = alphaCurve.Evaluate(time01);
        Color c = _spriteRenderer.color;
        c.a = currentAlpha;
        _spriteRenderer.color = c;
    }
}