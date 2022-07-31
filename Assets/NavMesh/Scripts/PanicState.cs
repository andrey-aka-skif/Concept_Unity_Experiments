using System;
using UnityEngine.AI;

namespace Assets.NavMesh
{
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
