using UnityEngine;

namespace SteelHeart.HFSM
{
    public class ClosingDoorState : StateMachine
    {
        public ClosingDoorState(LiftHFSM currentContext,
                                float speed,
                                Transform upPoint,
                                Transform downPoint,
                                Transform platform,
                                Animator animator,
                                StatesFactory stateFactory) 
            : base(currentContext, speed, upPoint, downPoint, platform, animator, stateFactory)
        {
            IsRootState = true;
        }

        protected override void OnEnter()
        {
            _animator.SetTrigger("Close");
        }

        protected override void OnGetAnimationEvent(string param)
        {
            if (param == "closed")
                SwitchState(Factory.GetSate<ClosedDoorState>());
        }
    }
}
