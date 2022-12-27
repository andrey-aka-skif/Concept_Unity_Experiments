using System;
using System.Collections.Generic;
using UnityEngine;

namespace SteelHeart.HFSM
{
    public abstract class StateMachine
    {
        private bool _isRootState = false;
        private readonly LiftHFSM _ctx;
        private readonly StatesFactory _factory;
        private StateMachine _currentSubState;
        private StateMachine _currentSuperState;

        protected float _speed;
        protected Transform _upPoint;
        protected Transform _downPoint;
        protected Transform _platform;
        protected Animator _animator;

        protected bool IsRootState { set => _isRootState = value; }
        protected LiftHFSM Ctx => _ctx;
        protected StatesFactory Factory => _factory;

        protected StateMachine(LiftHFSM currentContext,
                               float speed,
                               Transform upPoint,
                               Transform downPoint,
                               Transform platform,
                               Animator animator,
                               StatesFactory stateFactory)
        {
            _ctx = currentContext;
            _factory = stateFactory;

            _speed = speed;
            _upPoint = upPoint;
            _downPoint = downPoint;
            _platform = platform;
            _animator = animator;
        }

        protected virtual void OnEnter() { }
        protected virtual void OnUpdate() { }
        protected virtual void OnExit() { }

        public void EnterState()
        {
            OnEnter();
            _currentSubState?.EnterState();
        }

        public void UpdateState()
        {
            OnUpdate();
            _currentSubState?.UpdateState();
        }

        public void ExitState()
        {
            _currentSubState?.ExitState();
            OnExit();
        }

        protected void SwitchState(StateMachine newState)
        {
            ExitState();
            newState.EnterState();

            if (_isRootState)
                _ctx.CurrentState = newState;
            else
                _currentSuperState?.SetSubState(newState);
        }

        protected void SetSuperState(StateMachine newSuperState)
        {
            _currentSuperState = newSuperState;
        }

        protected void SetSubState(StateMachine newSubState)
        {
            _currentSubState = newSubState;
            newSubState.SetSuperState(this);
        }

        protected virtual void OnGetAnimationEvent(string param) { }
        protected virtual void OnCall() { }

        public void GetAnimationEvent(string param)
        {
            OnGetAnimationEvent(param);
            _currentSubState?.GetAnimationEvent(param);
        }

        public void Call()
        {
            OnCall();
            _currentSubState?.Call();
        }
    }
}
