using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SteelHeart.Interactable
{
    [RequireComponent(typeof(Animator))]
    public class Lift : MonoBehaviour, IStateSwitcher
    {
        [SerializeField] private float _speed = 1f;

        [SerializeField] private AbstractActivatedSource _callToDownButton;
        [SerializeField] private AbstractActivatedSource _callToUpButton;
        [SerializeField] private AbstractActivatedSource _moveButton;

        [SerializeField] private Transform _upPoint;
        [SerializeField] private Transform _downPoint;
        [SerializeField] private Transform _platform;

        private List<BaseLiftState> _states;
        private BaseLiftState _currentState;

        private Animator _animator;

        public bool _hasCallToUp = false;
        public bool _hasCallToDown = false;

        public enum Direction { none, up, down}

        private void Start()
        {
            _animator = GetComponent<Animator>();

            _platform.position = _downPoint.position;

            _states = new List<BaseLiftState>()
            {
                new ClosedDoorsState(this, this, _speed, _upPoint, _downPoint, _platform, _animator),
                new OpenedDoorsState(this, this, _speed, _upPoint, _downPoint, _platform, _animator),
                new OpeningDoorsState(this, this, _speed, _upPoint, _downPoint, _platform, _animator),
                new ClosingDoorsState(this, this, _speed, _upPoint, _downPoint, _platform, _animator),
                new MovingState(this, this, _speed, _upPoint, _downPoint, _platform, _animator)
            };

            _currentState = _states[0];
            _currentState.Start();
        }

        private void Awake()
        {
            _callToUpButton.Activated += OnCallToUp;
            _callToDownButton.Activated += OnCallToDown;
            _moveButton.Activated += OnCallMove;
        }

        private void OnCallMove() =>
            _currentState.OnCallMove();

        private void OnCallToDown() =>
            _currentState.OnCallToDown();

        private void OnCallToUp() =>
            _currentState.OnCallToUp();

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
                OnCallMove();

            if (Input.GetKey(KeyCode.UpArrow))
                OnCallToUp();

            if (Input.GetKey(KeyCode.DownArrow))
                OnCallToDown();

            _currentState.Update();
        }

        private void OnAnimationEvent(string param)
        {
            _currentState.OnAnimationEvent(param);
        }

        public void Switch<T>() where T : BaseLiftState
        {
            _currentState.Stop();
            _currentState = _states.FirstOrDefault(s => s is T);
            _currentState.Start();
        }
    }
}
