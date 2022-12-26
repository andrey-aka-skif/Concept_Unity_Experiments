using UnityEngine;

namespace iHeartGameDev
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private PlayerBaseState _currentState;
        private PlayerStateFactory _states;

        public PlayerBaseState CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }

        private void Awake()
        {
            _states = new PlayerStateFactory(this);
            _currentState = _states.Grounded();
            _currentState.EnterState();
        }

        private void Update()
        {
            _currentState.UpdateStates();
        }
    }
}
