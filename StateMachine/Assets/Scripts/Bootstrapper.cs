using UnityEngine;
using TMPro;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] PlayerContext _playerContext;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] TMP_Text _hudText;
    InputReader _inputReader;
    StateMachine _playerSM;
    StateMachine _gameSM;

    void Awake()
    {
        _inputReader = new InputReader();
        _inputReader.OnMove += HandleMove;
        _playerMovement.Init(_playerContext);
        _playerSM = new StateMachine();
        var initializer = new PlayerStateInitializer();
        var stateSequence = initializer.Initialize(_playerSM, _playerContext, _inputReader);
        new PlayerStateSwitcher(_playerSM, stateSequence, _inputReader, _hudText);
        _gameSM = new StateMachine();
        _gameSM.AddState(new GameState(_inputReader));
        _gameSM.AddState(new PauseState());
        _gameSM.AddState(new FinalState(_playerContext, _playerMovement));
        _inputReader.OnTogglePause += TogglePause;
        _inputReader.OnFinalState += SetFinalState;
        _gameSM.ChangeState<GameState>(); 
    }

    void Update()
    {
        _gameSM.Update();
        _playerSM.Update();
        if (_gameSM.CurrentState is GameState) _playerMovement.Tick();
    }

    void HandleMove(Vector2 direction) => _playerContext.MoveDirection = direction;

    void TogglePause()
    {
        if (_gameSM.CurrentState is GameState) _gameSM.ChangeState<PauseState>();
        else if (_gameSM.CurrentState is PauseState) _gameSM.ChangeState<GameState>();
    }

    void SetFinalState()
    {
        if (!(_gameSM.CurrentState is FinalState)) _gameSM.ChangeState<FinalState>();
    }

    void OnDestroy()
    {
        if (_inputReader != null)
        {
            _inputReader.OnMove -= HandleMove;
            _inputReader.OnTogglePause -= TogglePause;
            _inputReader.OnFinalState -= SetFinalState;
            _inputReader.DisableGameInput(); 
        }
    }
}