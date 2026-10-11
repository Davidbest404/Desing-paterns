using System;
using TMPro;
public class PlayerStateSwitcher
{
    StateMachine _stateMachine;
    Type[] _stateSequence;
    int _currentIndex = 0;
    TMP_Text _hudText;

    public PlayerStateSwitcher(StateMachine sm, Type[] sequence, InputReader input, TMP_Text hudText)
    {
        _stateMachine = sm;
        _stateSequence = sequence;
        _hudText = hudText;
        input.OnSwitchPlayerState += SwitchNextState;
        SwitchNextState();
    }

    void SwitchNextState()
    {
        Type nextType = _stateSequence[_currentIndex];
        _stateMachine.ChangeState(nextType);
        _hudText.text = $"Current State: {nextType.Name}";
        _currentIndex = (_currentIndex + 1) % _stateSequence.Length;
    }
}
