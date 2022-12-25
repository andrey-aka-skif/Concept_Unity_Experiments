using UnityEngine;

namespace SteelHeart.HFSM
{
    public class MovingState : StateMachine
    {
        public MovingState(LiftHFSM lift,
                           float speed,
                           Transform upPoint,
                           Transform downPoint,
                           Transform platform,
                           Animator animator, 
                           StatesFactory factory) : base(lift, speed, upPoint, downPoint, platform, animator, factory)
        {
        }

        protected override void OnEnter()
        {
            Debug.Log("MovingState OnEnter");
        }
    }
}
