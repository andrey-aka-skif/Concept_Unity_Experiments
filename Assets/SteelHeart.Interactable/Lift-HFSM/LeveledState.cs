using UnityEngine;

namespace SteelHeart.HFSM
{
    [System.Obsolete]
    public class LeveledState : StateMachine
    {
        public LeveledState(LiftHFSM lift,
                            float speed,
                            Transform upPoint,
                            Transform downPoint,
                            Transform platform,
                            Animator animator,
                            StatesFactory factory) 
            : base(lift, speed, upPoint, downPoint, platform, animator, factory)
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
