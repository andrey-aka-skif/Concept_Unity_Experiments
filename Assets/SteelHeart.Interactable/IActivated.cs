using System;

namespace SteelHeart.Interactable
{
    public interface IActivated
    {
        event Action Activated;
        event Action<Action> ActivatedWithCallback;
    }
}
