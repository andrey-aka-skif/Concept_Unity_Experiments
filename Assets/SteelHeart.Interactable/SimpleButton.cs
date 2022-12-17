using UnityEngine;

namespace SteelHeart.Interactable
{
    public class SimpleButton : AbstractActivatedSource
    {
        private bool _pressed;

        public override void Interact()
        {
            if (_pressed)
            {
                Debug.Log("Невозможно нажать");
                return;
            }

            Debug.Log("нажимаем");

            _pressed = true;
            base.Interact();
        }

        public void UnPress()
        {
            Debug.Log("отжата");
            _pressed = false;
        }
    }
}
