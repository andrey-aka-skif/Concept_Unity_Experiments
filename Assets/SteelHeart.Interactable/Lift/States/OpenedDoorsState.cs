using UnityEngine;

namespace SteelHeart.Interactable
{
    public class OpenedDoorsState : BaseLiftState
    {
        private float _elapsed;
        private float _openedTime = 2;

        public OpenedDoorsState(Lift lift, IStateSwitcher switcher,
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

            if (UpLevel)
                _lift._hasCallToUp = false;

            if (DownLevel)
                _lift._hasCallToDown = false;

            _elapsed = 0;
        }

        public override void Update()
        {
            _elapsed += Time.deltaTime;

            if (_elapsed < _openedTime)
                return;

            if (_lift._hasCallToDown || _lift._hasCallToUp)
                _switcher.Switch<ClosingDoorsState>();
        }

        public override void OnCallMove()
        {
            base.OnCallMove();

            if (DownLevel)
                _lift._hasCallToUp = true;

            if (UpLevel)
                _lift._hasCallToDown = true;

            _switcher.Switch<ClosingDoorsState>();
        }

        /*
        public override void OnCallToDown()
        {
            if (DownLevel)
                return;

            base.OnCallToDown();
        }

        public override void OnCallToUp()
        {
            if (UpLevel)
                return;

            base.OnCallToUp();
        }
        */
    }
}
