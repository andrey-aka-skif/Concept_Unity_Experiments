using UnityEngine;

namespace SteelHeart.Interactable
{

    public class OpeningDoorsState : EndedState
    {
        private Animator _animator;

        public OpeningDoorsState(IStateSwitcher switcher,
                           float speed,
                           Transform upPoint,
                           Transform downPoint,
                           Transform platform,
                           Animator animator)
            : base(switcher, speed, upPoint, downPoint, platform)
        {
            _animator = animator;
        }

        public override void Start()
        {
            base.Start();
            _animator.SetTrigger("Open");
        }

        public override void Update()
        {
            base.Update();
        }
    }

    public class OpenedDoorsState : EndedState
    {
        public OpenedDoorsState(IStateSwitcher switcher,
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
    }

    public class ClosingDoorsState : EndedState
    {
        public ClosingDoorsState(IStateSwitcher switcher,
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
    }
}
