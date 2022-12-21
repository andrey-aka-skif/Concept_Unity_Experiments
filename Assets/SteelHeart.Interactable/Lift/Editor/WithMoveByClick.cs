using UnityEngine;

namespace SteelHeart.Interactable
{
    public class WithMoveByClick : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //transform.position += .2f * new Vector3(0, 1, 0);
            }
        }
    }
}
