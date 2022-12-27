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

        private StateMachine _currentState;
        private StatesFactory _states;

        public StateMachine CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }

        public bool HasCallToUp { get; set; }
        public bool HasCallToDown { get; set; }

        private void Awake()
        {
            _platform.position = _downPoint.position;
            _animator = GetComponent<Animator>();

            _states = new StatesFactory(this, _speed, _upPoint, _downPoint, _platform, _animator);
            _currentState = _states.GetSate<ClosedDoorState>();
            _currentState.EnterState();
        }

        private void OnCallMove()
        {
            if (DownLevel)
                HasCallToUp = true;

            if (UpLevel)
                HasCallToDown = true;

            _currentState.Call();
        }

        private void OnCallToDown()
        {
            HasCallToDown = true;
            _currentState.Call();
        }

        private void OnCallToUp()
        {
            HasCallToUp = true;
            _currentState.Call();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
                OnCallMove();

            if (Input.GetKey(KeyCode.UpArrow))
                OnCallToUp();

            if (Input.GetKey(KeyCode.DownArrow))
                OnCallToDown();

            _currentState.UpdateState();
        }

        private void OnAnimationEventHFSM(string param)
        {
            _currentState.GetAnimationEvent(param);
        }

        public bool DownLevel
        {
            get
            {
                float distanceToDownPoint = Vector3.Distance(_platform.position, _downPoint.position);

                if (distanceToDownPoint < Mathf.Epsilon)
                    return true;

                return false;
            }
        }

        public bool UpLevel
        {
            get
            {
                float distanceToUpPoint = Vector3.Distance(_platform.position, _upPoint.position);

                if (distanceToUpPoint < Mathf.Epsilon)
                    return true;

                return false;
            }
        }
    }
}
