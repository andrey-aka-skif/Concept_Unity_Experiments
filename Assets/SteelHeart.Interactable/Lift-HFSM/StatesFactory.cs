﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace SteelHeart.HFSM
{
    public class StatesFactory
    {
        private readonly Dictionary<Type, StateMachine> _states = new();

        protected LiftHFSM _lift;
        protected float _speed;
        protected Transform _upPoint;
        protected Transform _downPoint;
        protected Transform _platform;
        protected Animator _animator;

        public StatesFactory(LiftHFSM lift,
                               float speed,
                               Transform upPoint,
                               Transform downPoint,
                               Transform platform,
                               Animator animator)
        {
            _lift = lift;
            _speed = speed;
            _upPoint = upPoint;
            _downPoint = downPoint;
            _platform = platform;
            _animator = animator;

            CreateStates();
        }

        private void CreateStates()
        {
            _states.Add(typeof(ClosedDoorState),
                        new ClosedDoorState(_lift, _speed, _upPoint, _downPoint, _platform, _animator, this));

            _states.Add(typeof(OpeningDoorState),
                        new OpeningDoorState(_lift, _speed, _upPoint, _downPoint, _platform, _animator, this));

            _states.Add(typeof(OpenedDoorState),
                        new OpenedDoorState(_lift, _speed, _upPoint, _downPoint, _platform, _animator, this));

            _states.Add(typeof(ClosingDoorState),
                        new ClosingDoorState(_lift, _speed, _upPoint, _downPoint, _platform, _animator, this));

            _states.Add(typeof(MovingState),
                        new MovingState(_lift, _speed, _upPoint, _downPoint, _platform, _animator, this));
        }

        public StateMachine GetSate<T>() where T : StateMachine
        {
            return _states[typeof(T)];
        }
    }
}