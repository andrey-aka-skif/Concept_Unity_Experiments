using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.NavMesh
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Sheep : MonoBehaviour, IStateSwitcher
    {
        [SerializeField] private float _calmDistance = 2.0f;
        [SerializeField] private float _alertDistance = 1.0f;
        [SerializeField] private float _panicDistance = 0.5f;

        public float CalmDistance => _calmDistance;
        public float AlarmDistance => _alertDistance;
        public float PanicDistance => _panicDistance;

        public Vector3 Position => transform.position;

        private BaseState _currentState;
        private List<BaseState> _allStates;
        private NavMeshAgent _agent;

        public void Setup(IWolf wolf)
        {
            _agent = GetComponent<NavMeshAgent>();

            _allStates = new List<BaseState>()
            {
                new CalmState(this, wolf, _agent, this),
                new AlarmState(this, wolf, _agent, this),
                new PanicState(this, wolf, _agent, this)
            };
            _currentState = _allStates[0];
            _currentState.Start();
        }

        private void Update()
        {
            _currentState.Update();
        }

        public void SwitchState<T>() where T : BaseState
        {
            var state = _allStates.FirstOrDefault(s => s is T);
            _currentState.Stop();
            state.Start();
            _currentState = state;
        }
    }
}
