using UnityEngine;

namespace SteelHeart.Interactable
{
    public abstract class BaseLiftState
    {
        protected Lift _lift;
        protected IStateSwitcher _switcher;
        protected float _speed;
        protected Transform _upPoint;
        protected Transform _downPoint;
        protected Transform _platform;

        protected Animator _animator;

        //protected bool _hasCallToUp = false;
        //protected bool _hasCallToDown = false;

        protected BaseLiftState(Lift lift,
                                IStateSwitcher switcher,
                                float speed,
                                Transform upPoint,
                                Transform downPoint,
                                Transform platform,
                                Animator animator)
        {
            _lift = lift;
            _switcher = switcher;
            _speed = speed;
            _upPoint = upPoint;
            _downPoint = downPoint;
            _platform = platform;
            _animator = animator;
        }

        public float PositionInPercents { get; protected set; }

        public virtual void Start() => Debug.Log(GetType().Name);
        public virtual void Stop() { }
        public abstract void Update();
        public virtual void OnCallToUp()
        {
            if (UpLevel)
                return;

            _lift._hasCallToUp = true;
        }
        public virtual void OnCallToDown()
        {
            if (DownLevel)
                return;

            _lift._hasCallToDown = true;
        }
        public virtual void OnCallMove()
        {
            //if (DownLevel)
            //    _hasCallToUp = true;

            //if (UpLevel)
            //    _hasCallToDown = true;
        }

        public virtual void OnAnimationEvent(string param) { }

        protected bool HasCallToOwnLevel()
        {
            if (DownLevel && _lift._hasCallToDown)
                return true;

            if (UpLevel && _lift._hasCallToUp)
                return true;

            return false;
        }

        protected bool HasCallToAnotherLevel()
        {
            if (DownLevel && _lift._hasCallToUp)
                return true;

            if (UpLevel && _lift._hasCallToDown)
                return true;

            return false;
        }

        protected bool UpLevel
        {
            get
            {
                float distanceToUpPoint = Vector3.Distance(_platform.position, _upPoint.position);

                if (distanceToUpPoint < Mathf.Epsilon)
                    return true;

                return false;
            }
        }

        protected bool DownLevel
        {
            get
            {
                float distanceToDownPoint = Vector3.Distance(_platform.position, _downPoint.position);

                if (distanceToDownPoint < Mathf.Epsilon)
                    return true;

                return false;
            }
        }
    }
}
