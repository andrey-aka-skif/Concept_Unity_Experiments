namespace SteelHeart.Interactable
{
    public interface IStateSwitcher
    {
        void Switch<T>() where T : BaseLiftState;
    }
}
