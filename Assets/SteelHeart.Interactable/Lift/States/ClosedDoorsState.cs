using UnityEngine;

namespace SteelHeart.Interactable
{
    public class ClosedDoorsState : EndedState
    {
        public ClosedDoorsState(IStateSwitcher switcher,
                           float speed,
                           Transform upPoint,
                           Transform downPoint,
                           Transform platform)
            : base(switcher, speed, upPoint, downPoint, platform)
        {
        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnCallToDown()
        {
            base.OnCallToDown();

            if (_isUpPosition)
                _switcher.Switch<MovingState>();
            else
                _switcher.Switch<OpeningDoorsState>();
        }
    }
}
