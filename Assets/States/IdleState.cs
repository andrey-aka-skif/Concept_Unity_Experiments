using UnityEngine;

namespace States
{
    public class IdleState : BaseState
    {
        public IdleState(IStateSwitcher switcher, Character character) : base(switcher, character)
        {
        }

        public override void Update()
        {
            if (_character.OnGround)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    _switcher.Switch<JumpState>();
            }
        }
    }
}
