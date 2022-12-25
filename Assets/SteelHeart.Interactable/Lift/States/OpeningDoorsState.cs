using UnityEngine;

namespace SteelHeart.Interactable
{
    public class OpeningDoorsState : BaseLiftState
    {
        public OpeningDoorsState(Lift lift, IStateSwitcher switcher,
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
            _animator.SetTrigger("Open");
        }

        public override void Update() { }

        public override void OnAnimationEvent(string param)
        {
            if (param == "open")
                _switcher.Switch<OpenedDoorsState>();
        }

        /*
        public override void OnCallToDown()
        {
            if (HasCallToOwnLevel())
                return;

            base.OnCallToDown();
        }

        public override void OnCallToUp()
        {
            if (HasCallToOwnLevel())
                return;

            base.OnCallToUp();
        }
        */
    }
}
