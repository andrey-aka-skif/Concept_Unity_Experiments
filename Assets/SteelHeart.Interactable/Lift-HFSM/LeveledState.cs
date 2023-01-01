using UnityEngine;

namespace SteelHeart.HFSM
{
    [System.Obsolete]
    public class LeveledState : BaseHierarchicalState
    {
        public LeveledState(LiftHFSM lift,
                            Transform upPoint,
                            Transform downPoint,
                            Transform platform,
                            Animator animator,
                            StatesFactory factory) 
            : base(lift, upPoint, downPoint, platform, animator, factory)
        {
            IsRootState = true;
        }

        protected override void OnEnter()
        {
            Debug.Log("LeveledState OnEnter");

            SetSubState(Factory.GetSate<ClosedDoorState>());
        }
    }
}
