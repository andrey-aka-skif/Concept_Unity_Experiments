using System;
using UnityEngine;

namespace SteelHeart.HFSM
{
    public class OpenedDoorState : StateMachine
    {
        private float _elapsed;
        private float _openedTime = 2;

        public OpenedDoorState(LiftHFSM currentContext,
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
            TryResetCalls();
            _elapsed = 0;
        }

        protected override void OnUpdate()
        {
            _elapsed += Time.deltaTime;

            if (_elapsed < _openedTime)
                return;

            CheckCalls();
        }

        protected override void OnCall()
        {
            TryResetCalls();
        }

        private void CheckCalls()
        {
            if (Ctx.DownLevel && Ctx.HasCallToUp)
                SwitchState(Factory.GetSate<ClosingDoorState>());

            if(Ctx.UpLevel && Ctx.HasCallToDown)
                SwitchState(Factory.GetSate<ClosingDoorState>());
        }

        private void TryResetCalls()
        {
            if (Ctx.DownLevel)
                Ctx.HasCallToDown = false;

            if (Ctx.UpLevel)
                Ctx.HasCallToUp = false;
        }
    }
}
