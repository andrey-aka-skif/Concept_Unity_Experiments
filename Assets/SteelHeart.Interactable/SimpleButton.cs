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
                Debug.Log("���������� ������");
                return;
            }

            Debug.Log("��������");

            _pressed = true;
            base.Interact();
        }

        public void UnPress()
        {
            Debug.Log("������");
            _pressed = false;
        }
    }
}
