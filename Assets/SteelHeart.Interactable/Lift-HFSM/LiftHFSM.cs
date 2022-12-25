using UnityEngine;

namespace SteelHeart.HFSM
{
    [RequireComponent(typeof(Animator))]
    public class LiftHFSM : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;

        [SerializeField] private Transform _upPoint;
        [SerializeField] private Transform _downPoint;
        [SerializeField] private Transform _platform;

        private Animator _animator;
        private StatesFactory _factory;
        private StateMachine _stateMachine;

        public bool HasCallToUp = false;
        public bool HasCallToDown = false;

        private void Start()
        {
            _platform.position = _downPoint.position;
            _animator = GetComponent<Animator>();

            _factory = new StatesFactory(this, _speed, _upPoint, _downPoint, _platform, _animator);

            _stateMachine = _factory.GetSate<LeveledState>();
            //_stateMachine.AddSubState(_factory.GetSate<CloseDoorState>());
            
            _stateMachine.EnterStateMachine();
        }

        private void OnCallMove() => _stateMachine.OnCallMove();

        private void OnCallToDown() => _stateMachine.OnCallToDown();

        private void OnCallToUp() => _stateMachine.OnCallToUp();

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
                OnCallMove();

            if (Input.GetKey(KeyCode.UpArrow))
                OnCallToUp();

            if (Input.GetKey(KeyCode.DownArrow))
                OnCallToDown();

            _stateMachine.UpdateStateMachine();
        }

        private void OnAnimationEvent(string param)
        {
            _stateMachine.OnAnimationEvent(param);
        }
    }
}
