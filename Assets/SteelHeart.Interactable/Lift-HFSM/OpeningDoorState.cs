using UnityEngine;

namespace SteelHeart.HFSM
{
    public class OpeningDoorState : StateMachine
    {
        public OpeningDoorState(LiftHFSM currentContext,
                                float speed,
                                Transform upPoint,
                                Transform downPoint,
                                Transform platform,
                                Animator animator,
                                StatesFactory stateFactory) : base(currentContext, speed, upPoint, downPoint, platform, animator, stateFactory)
        {
            IsRootState = true;
        }

        protected override void OnEnter()
        {
            Debug.Log("OpeningDoorState OnEnter");

            _animator.SetTrigger("Open");
        }

        protected override void OnGetAnimationEvent(string param)
        {
            if (param == "open")
                Debug.Log("Открыто");
        }
    }
}
