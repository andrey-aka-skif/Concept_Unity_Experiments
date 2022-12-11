using GroundCheck;
using UnityEngine;

namespace States
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private GroundChecker _groundChecker;

        private MovementStateMachine _movementStateMachine;

        public bool OnGround => _groundChecker.IsGrounded;

        private void Start()
        {
            _movementStateMachine = new MovementStateMachine(this);
        }

        private void Update()
        {
            _movementStateMachine.Update();
        }
    }
}
