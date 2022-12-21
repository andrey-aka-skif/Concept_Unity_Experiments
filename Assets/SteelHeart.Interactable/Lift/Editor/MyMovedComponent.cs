using UnityEngine;

namespace SteelHeart.Interactable
{
    public class MyMovedComponent : MonoBehaviour
    {
        private void Update()
        {
            //transform.hasChanged = false;
            if (Input.GetMouseButtonUp(0))
                transform.position += 0.1f * transform.right;

            if (Input.GetMouseButton(1))
                transform.position += 0.5f * Time.deltaTime * transform.right;
        }
    }
}
