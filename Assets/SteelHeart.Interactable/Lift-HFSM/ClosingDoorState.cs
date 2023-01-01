using UnityEngine;

namespace SteelHeart.HFSM
{
    public class ClosingDoorState : BaseHierarchicalState
    {
        public ClosingDoorState(LiftHFSM currentContext,
                                Transform upPoint,
                                Transform downPoint,
                                Transform platform,
                                Animator animator,
                                StatesFactory stateFactory) 
            : base(currentContext, upPoint, downPoint, platform, animator, stateFactory)
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
