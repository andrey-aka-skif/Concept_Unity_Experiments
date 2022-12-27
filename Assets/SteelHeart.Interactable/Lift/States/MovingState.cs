using UnityEngine;

namespace SteelHeart.Interactable
{
    public class MovingState : BaseLiftState
    {
        private float _elapsedTime;
        private float _timeToEndPoint;
        private bool _isMoveUp;

        public MovingState(Lift lift, IStateSwitcher switcher,
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

            if (DownLevel)
                _isMoveUp = true;

            if (UpLevel)
                _isMoveUp = false;

            //float distanceToDownPoint = Vector3.Distance(_platform.position, _downPoint.position);

            //if (distanceToDownPoint < Mathf.Epsilon)
            //{
            //    _isMoveUp = true;
            //    _hasCallToUp = false;
            //}
            //else
            //{
            //    _isMoveUp = false;
            //    _hasCallToDown = false;
            //}

            _elapsedTime = 0;
            float distance = Vector3.Distance(_downPoint.position, _upPoint.position);
            _timeToEndPoint = distance / _speed;
        }

        public override void Update()
        {
            _elapsedTime += Time.deltaTime;

            float elapsedPercentage = _elapsedTime / _timeToEndPoint;

            if (_isMoveUp)
                _platform.position = Vector3.Lerp(_downPoint.position, _upPoint.position, elapsedPercentage);
            else
                _platform.position = Vector3.Lerp(_upPoint.position, _downPoint.position, elapsedPercentage);

            //if (elapsedPercentage >= 1)
            //    _switcher.Switch<OpeningDoorsState>();

            if (elapsedPercentage >= 1)
            {

                _switcher.Switch<ClosedDoorsState>();
            }
        }

        public override void OnCallToUp()
        {
            _lift._hasCallToUp = true;
        }

        public override void OnCallToDown()
        {
            _lift._hasCallToDown = true;
        }

        public override void Stop()
        {
            base.Stop();

            if (_isMoveUp)
            {
                _platform.position = _upPoint.position;
                //_hasCallToUp = false;
            }
            else
            {
                _platform.position = _downPoint.position;
                //_hasCallToDown = false;
            }
        }
    }
}
