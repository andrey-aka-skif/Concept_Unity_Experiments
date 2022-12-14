using UnityEngine;

namespace SteelHeart.Interactable
{
    public class EventsCatcher : MonoBehaviour
    {
        [SerializeField] private LiftButton _button;

        private void OnButtonPush() =>
            Debug.Log("Нажата целевая кнопка");

        private void OnEnable() =>
            _button.Activated += OnButtonPush;

        private void OnDisable() =>
            _button.Activated -= OnButtonPush;
    }
}
