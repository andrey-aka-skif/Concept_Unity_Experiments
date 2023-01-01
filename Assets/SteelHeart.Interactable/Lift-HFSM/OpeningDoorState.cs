using UnityEngine;

namespace SteelHeart.HFSM
{
    public class OpeningDoorState : StateMachine
    {
        public OpeningDoorState(LiftHFSM currentContext,
                                Transform upPoint,
                                Transform downPoint,
                                Transform platform,
                                Animator animator,
                                StatesFactory stateFactory) : base(currentContext, upPoint, downPoint, platform, animator, stateFactory)
        {
            IsRootState = true;
        }

        protected override void OnEnter()
        {
            _animator.SetTrigger("Open");
        }

        protected override void OnGetAnimationEvent(string param)
        {
            if (param == "opened")
                SwitchState(Factory.GetSate<OpenedDoorState>());
        }
    }
}
