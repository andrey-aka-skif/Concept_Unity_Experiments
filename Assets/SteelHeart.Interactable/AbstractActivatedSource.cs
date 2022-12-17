using System;
using UnityEngine;

namespace SteelHeart.Interactable
{
    public abstract class AbstractActivatedSource : MonoBehaviour, IInteractable, IActivated
    {
        public event Action Activated;
        public event Action<Action> ActivatedWithCallback;

        public virtual void Interact()
        {
            Activated?.Invoke();
            ActivatedWithCallback?.Invoke(CompleteHandler);
        }

        protected virtual void CompleteHandler() { }
    }
}
