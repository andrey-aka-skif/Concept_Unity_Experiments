using UnityEngine;

namespace SteelHeart.Interactable
{
    public abstract class EndedState : BaseLiftState
    {
        protected bool _isUpPosition = false;

        public EndedState(IStateSwitcher switcher,
                           float speed,
                           Transform upPoint,
                           Transform downPoint,
                           Transform platform)
            : base(switcher, speed, upPoint, downPoint, platform)
        {
        }

        public override void Start()
        {
            base.Start();

            float distance = Vector3.Distance(_platform.position, _upPoint.position);

            if (distance < Mathf.Epsilon)
                _isUpPosition = true;
        }

        public override void Update()
        {
        }
    }
}
