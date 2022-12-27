using UnityEngine;

namespace SteelHeart.Interactable
{
    public class ClosedDoorsState : BaseLiftState
    {
        public ClosedDoorsState(Lift lift, IStateSwitcher switcher,
                           float speed,
                           Transform upPoint,
                           Transform downPoint,
                           Transform platform,
                           Animator animator)
            : base(lift, switcher, speed, upPoint, downPoint, platform, animator)
        {
        }

        public override void Start()
        {
            base.Start();

            if (HasCallToOwnLevel())
                _switcher.Switch<OpeningDoorsState>();

            if (HasCallToAnotherLevel())
                _switcher.Switch<MovingState>();
        }

        public override void Update() { }

        public override void OnCallToDown()
        {
            if (DownLevel)
                _switcher.Switch<OpeningDoorsState>();

            if (UpLevel)
            {
                _lift._hasCallToDown = true;
                _switcher.Switch<MovingState>();
            }
        }

        public override void OnCallToUp()
        {
            if (DownLevel)
            {
                _lift._hasCallToUp = true;
                _switcher.Switch<MovingState>();
            }

            if (UpLevel)
                _switcher.Switch<OpeningDoorsState>();
        }
    }
}
