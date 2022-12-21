using UnityEngine;

namespace SteelHeart.Interactable
{
    public class MovingDownState : BaseLiftState
    {
        public MovingDownState(IStateSwitcher switcher,
                               float speed,
                               Transform upPoint,
                               Transform downPoint,
                               Transform platform)
            : base(switcher, speed, upPoint, downPoint, platform)
        {
        }

        public override void Update() { }
    }
}
