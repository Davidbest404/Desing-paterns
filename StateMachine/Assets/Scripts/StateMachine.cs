using System;
using System.Collections.Generic;
public class StateMachine
{
    Dictionary<Type, BaseState> _states = new Dictionary<Type, BaseState>();
    public BaseState CurrentState { get; private set; }
    public void AddState(BaseState state) => _states[state.GetType()] = state;
    public void ChangeState<T>() where T : BaseState
    {
        ChangeState(typeof(T));
    }

    public void ChangeState(Type stateType)
    {
        if (_states.TryGetValue(stateType, out BaseState nextState))
        {
            CurrentState?.Exit();
            CurrentState = nextState;
            CurrentState?.Enter();
        }
        else UnityEngine.Debug.LogError($"Состояние {stateType.Name} не найдено");
    }
    public void Update() => CurrentState?.Update();
}