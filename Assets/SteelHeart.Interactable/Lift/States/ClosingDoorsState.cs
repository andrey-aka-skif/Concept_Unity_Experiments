using UnityEngine;

namespace SteelHeart.Interactable
{
    public class ClosingDoorsState : BaseLiftState
    {
        public ClosingDoorsState(Lift lift, IStateSwitcher switcher,
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
            _animator.SetTrigger("Close");
        }

        public override void Update() { }

        public override void OnAnimationEvent(string param)
        {
            //if (param == "close")
            //    _switcher.Switch<MovingState>();

            if (param == "close")
                _switcher.Switch<ClosedDoorsState>();
        }
    }
}
