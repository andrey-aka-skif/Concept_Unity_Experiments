namespace States
{
    public abstract class BaseState
    {
        protected IStateSwitcher _switcher;
        protected Character _character;

        public BaseState(IStateSwitcher switcher, Character character)
        {
            _switcher = switcher;
            _character = character;
        }

        public virtual void Start() { }
        public virtual void Stop() { }
        public abstract void Update();
    }
}
