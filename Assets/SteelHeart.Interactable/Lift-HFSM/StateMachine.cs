using System;
using System.Collections.Generic;
using UnityEngine;

namespace SteelHeart.HFSM
{
    public abstract class StateMachine
    {
        private StateMachine _currentSuperState;
        private StateMachine _currentSubState;
        //private StateMachine _defaultSubState;
        //public StateMachine _parent;
        //private readonly Dictionary<Type, StateMachine> _subStates = new();

        protected bool _isRootState = false;

        protected LiftHFSM _lift;
        protected float _speed;
        protected Transform _upPoint;
        protected Transform _downPoint;
        protected Transform _platform;
        protected Animator _animator;
        protected StatesFactory _factory;

        protected StateMachine(LiftHFSM lift,
                               float speed,
                               Transform upPoint,
                               Transform downPoint,
                               Transform platform,
                               Animator animator,
                               StatesFactory factory)
        {
            _lift = lift;
            _speed = speed;
            _upPoint = upPoint;
            _downPoint = downPoint;
            _platform = platform;
            _animator = animator;
            _factory = factory;
        }

        public void EnterStateMachine()
        {
            OnEnter();
            /*
            if (_currentSubState == null && _defaultSubState != null)
            {
                _currentSubState = _defaultSubState;
            }
            */
            _currentSubState?.EnterStateMachine();
        }

        public void UpdateStateMachine()
        {
            OnUpdate();
            _currentSubState?.UpdateStateMachine();
        }

        public void ExitStateMachine()
        {
            _currentSubState?.ExitStateMachine();
            OnExit();
        }

        public virtual void OnCallMove()
        {
            _currentSubState?.OnCallMove();
        }

        public virtual void OnCallToDown()
        {
            _currentSubState?.OnCallToDown();
        }

        public virtual void OnCallToUp()
        {
            _currentSubState?.OnCallToUp();
        }

        protected virtual void OnEnter() { }

        protected virtual void OnUpdate() { }

        protected virtual void OnExit() { }

        /*
        public void AddSubState(StateMachine subState)
        {
            if (_subStates.Count == 0)
            {
                _defaultSubState = subState;
            }

            subState.Parent = this;
            try
            {
                _subStates.Add(subState.GetType(), subState);
            }
            catch (ArgumentException)
            {
                throw new Exception($"State {this.GetType()} already contains a substate of type {subState.GetType()}");
            }
        }
        */

        public void OnAnimationEvent(string param)
        {
            _currentSubState?.OnAnimationEvent(param);
        }

        //public void Switch<T>() where T : StateMachine
        //{
        //    _currentSubState?.ExitStateMachine();
        //    _currentSubState = _subStates[typeof(T)];
        //    _currentSubState.EnterStateMachine();
        //}

        public void SetSuperState(StateMachine state)
        {
            _currentSuperState = state;
        }

        public void SetSubState(StateMachine state)
        {
            _currentSubState = state;
            state.SetSuperState(this);
        }

        public void Switch(StateMachine newState)
        {
            OnExit();

            newState.EnterStateMachine();

            if (_isRootState)
            {
                _currentSuperState.SetSubState(newState);
            }
            else if (_currentSuperState != null)
            {
                _currentSuperState.SetSubState(newState);
            }
        }
    }
}
