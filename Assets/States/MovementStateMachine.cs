using System.Collections.Generic;
using System.Linq;

namespace States
{
    public class MovementStateMachine : IStateSwitcher
    {
        private readonly List<BaseState> _states;
        private BaseState _currentState;
        public MovementStateMachine(Character character)
        {
            _states = new List<BaseState>()
            {
                new IdleState(this, character),
                new JumpState(this, character)
            };

            _currentState = _states[0];
            _currentState.Start();
        }

        public void Update()
        {
            _currentState.Update();
        }

        public void Switch<T>() where T : BaseState
        {
            _currentState.Stop();
            _currentState = _states.FirstOrDefault(s =>  s is T);
            _currentState.Start();
        }
    }
}
