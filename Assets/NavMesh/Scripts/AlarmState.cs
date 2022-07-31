using System;
using UnityEngine.AI;

namespace Assets.NavMesh
{
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
}
