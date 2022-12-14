using System;
using UnityEngine;

namespace SteelHeart.Interactable
{
    public class LiftButton : MonoBehaviour, IInteractable, IActivated
    {
        [SerializeField] private bool _delayed = true;

        private bool _isPressing;

        public event Action Activated;

        public void DoAction()
        {
            Debug.Log("пробуем нажать");
            if (_delayed && _isPressing)
                return;

            Debug.Log("нажимаем");

            _isPressing = true;
            Activated?.Invoke();
        }

        public void SetActive()
        {
            Debug.Log("отжата");
            _isPressing = false;
        }
    }
}
