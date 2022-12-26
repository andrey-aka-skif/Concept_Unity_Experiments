﻿namespace iHeartGameDev
{
    public abstract class PlayerBaseState
    {
        private bool _isRootState = false;
        private readonly PlayerStateMachine _ctx;
        private readonly PlayerStateFactory _factory;
        private PlayerBaseState _currentSubState;
        private PlayerBaseState _currentSuperState;

        protected bool IsRootState { set => _isRootState = value; }
        protected PlayerStateMachine Ctx => _ctx;
        protected PlayerStateFactory Factory => _factory;

        protected PlayerBaseState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        {
            _ctx = currentContext;
            _factory = playerStateFactory;
        }

        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();
        public abstract void CheckSwitchState();
        public abstract void InitializeSubState();

        public void UpdateStates()
        {
            UpdateState();
            if (_currentSubState != null)
            {
                _currentSubState.UpdateStates();
            }
        }

        // автор посчитал этот метод не нужным для данной HFSM
        public void ExitStates()
        {
            ExitState();
            if (_currentSubState != null)
            {
                _currentSubState.ExitStates();
            }
        }

        protected void SwitchState(PlayerBaseState newState)
        {
            ExitState();
            newState.EnterState();

            if (_isRootState)
            {
                _ctx.CurrentState = newState;
            }
            else if (_currentSuperState != null)
            {
                _currentSuperState.SetSubState(newState);
            }
        }
        protected void SetSuperState(PlayerBaseState newSuperState)
        {
            _currentSuperState = newSuperState;
        }
        protected void SetSubState(PlayerBaseState newSubState)
        {
            _currentSubState = newSubState;
            newSubState.SetSuperState(this);
        }
    }
}
