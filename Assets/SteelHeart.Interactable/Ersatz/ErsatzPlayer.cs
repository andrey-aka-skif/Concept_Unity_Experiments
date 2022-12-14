using UnityEngine;

namespace SteelHeart.Interactable
{
    public class ErsatzPlayer : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            if (!Input.GetKeyDown(KeyCode.E))
                return;

            if (other.transform.TryGetComponent(out IInteractable interactable))
                interactable.DoAction();
        }
    }
}
