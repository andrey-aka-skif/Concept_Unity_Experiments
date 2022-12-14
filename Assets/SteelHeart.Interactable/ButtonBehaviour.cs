using UnityEngine;

namespace SteelHeart.Interactable
{
    [RequireComponent(typeof(Animator), typeof(IActivated))]
    public class ButtonBehaviour : MonoBehaviour
    {
        private Animator _animator;
        private IActivated _activated;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _activated = GetComponent<IActivated>();
        }

        private void OnButtonPush()
        {
            _animator.SetTrigger("OnPress");
        }

        private void OnEnable() =>
            _activated.Activated += OnButtonPush;

        private void OnDisable() =>
            _activated.Activated -= OnButtonPush;
    }
}
