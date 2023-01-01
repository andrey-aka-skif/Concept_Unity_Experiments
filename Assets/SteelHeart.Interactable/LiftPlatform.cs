using UnityEngine;

namespace SteelHeart.Interactable
{
    public class LiftPlatform : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.transform.SetParent(transform);
        }

        private void OnTriggerExit(Collider other)
        {
            other.transform.SetParent(null);
        }
    }
}
