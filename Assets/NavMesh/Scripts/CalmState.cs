using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.NavMesh
{
    public class CalmState : BaseState
    {
        public CalmState(Sheep sheep, IWolf wolf, NavMeshAgent navMeshAgent, IStateSwitcher stateSwitcher)
            : base(sheep, wolf, navMeshAgent, stateSwitcher) { }

        public override void Start()
        {
            Vector3 destination = GetNextRndPositionSafely(_sheep.CalmDistance);
            _navMeshAgent.destination = destination;
        }

        public override void Update()
        {
            /*
            Debug.Log(_navMeshAgent.pathPending);
            Debug.Log(_navMeshAgent.hasPath);
            Debug.Log(_navMeshAgent.path.status);
            Debug.Log(_navMeshAgent.destination);
            Debug.Log("-----------");
            */

            // проверить близость волка
            if ((_sheep.Position - _wolf.Position).magnitude < _sheep.PanicDistance)
            {
                //_stateSwitcher.SwitchState<PanicState>();
                //return;
            }

            if ((_sheep.Position - _wolf.Position).magnitude < _sheep.AlarmDistance)
            {
                //_stateSwitcher.SwitchState<AlarmState>();
                //return;
            }

            //Debug.Log(_navMeshAgent.remainingDistance);

            // проверить достижение конечной точки
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                Vector3 destination = GetNextRndPositionSafely(_sheep.CalmDistance);
                _navMeshAgent.destination = destination;
            }

            if (_navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                //_navMeshAgent.destination = GetNextPosition(_sheep.CalmDistance);
                //return;
            }

            // проверить невозможность достичь конечную точку
            if (!_navMeshAgent.hasPath)
            {
                _navMeshAgent.destination = GetNextRndPosition(_sheep.CalmDistance);
                return;
            }
        }
    }

    public class AlarmState : BaseState
    {
        public AlarmState(Sheep sheep,
                          IWolf wolf,
                          NavMeshAgent navMeshAgent,
                          IStateSwitcher stateSwitcher) : base(sheep, wolf, navMeshAgent, stateSwitcher) { }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }

    public class PanicState : BaseState
    {
        public PanicState(Sheep sheep,
                          IWolf wolf,
                          NavMeshAgent navMeshAgent,
                          IStateSwitcher stateSwitcher) : base(sheep, wolf, navMeshAgent, stateSwitcher) { }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
