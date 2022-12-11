namespace States
{
    public interface IStateSwitcher
    {
        void Switch<T>() where T : BaseState;
    }
}