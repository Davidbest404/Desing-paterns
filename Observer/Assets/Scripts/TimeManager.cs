using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour, IObservable
{
    [SerializeField] float dayDurationInSeconds = 10f;
    List<IObserver> _observers = new List<IObserver>();
    float _currentTime;
    float _timeProgress;

    public void RegisterObserver(IObserver observer)
    {
        if (!_observers.Contains(observer)) _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (_observers.Contains(observer)) _observers.Remove(observer);
    }

    public void Notify()
    {
        for (int i = 0; i < _observers.Count; i++) _observers[i].OnNotify(_timeProgress);
    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        _currentTime %= dayDurationInSeconds;
        _timeProgress = _currentTime / dayDurationInSeconds;
        Notify();
    }
}