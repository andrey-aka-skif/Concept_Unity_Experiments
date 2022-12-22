using UnityEngine;

namespace SteelHeart.Interactable
{
    public abstract class BaseLiftState
    {
        protected IStateSwitcher _switcher;
        protected float _speed;
        protected Transform _upPoint;
        protected Transform _downPoint;
        protected Transform _platform;

        protected BaseLiftState(IStateSwitcher switcher,
                                float speed,
                                Transform upPoint,
                                Transform downPoint,
                                Transform platform)
        {
            _switcher = switcher;
            _speed = speed;
            _upPoint = upPoint;
            _downPoint = downPoint;
            _platform = platform;
        }

        public float PositionInPercents { get; protected set; }

        public virtual void Start()
        {
            Debug.Log(GetType().Name);
        }
        public virtual void Stop() { }
        public abstract void Update();

        public virtual void OnDoorsOpen() { }
        public virtual void OnDoorsClose() { }
        public virtual void OnCallToUp() { }
        public virtual void OnCallToDown() { }
        public virtual void OnCallMove() { }
    }
}
