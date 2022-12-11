using UnityEngine;

namespace States
{
    public class JumpState : BaseState
    {
        private readonly Rigidbody _rb;

        public JumpState(IStateSwitcher switcher, Character character) : base(switcher, character)
        {
            _rb = character.transform.GetComponent<Rigidbody>();
        }

        public override void Start()
        {
            _rb.AddForce(10 * Vector3.up, ForceMode.Impulse);
        }

        public override void Update()
        {
            if (_character.OnGround)
                _switcher.Switch<IdleState>();
        }
    }
}
