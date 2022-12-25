using UnityEngine;

namespace SteelHeart.HFSM
{
    public class CloseDoorState : StateMachine
    {
        public CloseDoorState(LiftHFSM lift,
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
            Debug.Log("CloseDoorState OnEnter");

            // если есть вызов на другой этаж
            // передать управление родителю (LeveledState)

            if (_lift.HasCallToUp)
            {
                // как передать управление родителю?
            }
        }
    }
}
