namespace Assets.NavMesh
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : BaseState;
    }
}
