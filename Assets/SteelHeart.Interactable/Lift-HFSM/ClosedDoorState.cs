using UnityEngine;

namespace SteelHeart.HFSM
{
    public class ClosedDoorState : StateMachine
    {
        public ClosedDoorState(LiftHFSM lift,
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
            Debug.Log("ClosedDoorState OnEnter");

            CheckCalls();
        }

        protected override void OnCall()
        {
            CheckCalls();
        }

        private void CheckCalls()
        {
            if (Ctx.DownLevel)
            {
                if (Ctx.HasCallToDown)
                    SwitchState(Factory.GetSate<OpeningDoorState>());

                if (Ctx.HasCallToUp)
                    Debug.Log("Едем вверх");
            }

            if (Ctx.UpLevel)
            {
                if (Ctx.HasCallToUp)
                {
                    // открыть дверь
                }

                if (Ctx.HasCallToDown)
                {
                    // едем вниз
                }
            }
        }
    }
}
