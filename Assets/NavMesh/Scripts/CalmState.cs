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

            // проверить достижение конечной точки
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                Vector3 destination = GetNextRndPositionSafely(_sheep.CalmDistance);
                _navMeshAgent.destination = destination;
            }
        }
    }
}
