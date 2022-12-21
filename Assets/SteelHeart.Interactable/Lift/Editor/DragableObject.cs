using UnityEngine;

namespace SteelHeart.Interactable
{
    public class DragableObject : MonoBehaviour
    {
        private Vector3 mOffset;
        private float mZCoord;

        private void OnMouseDrag()
        {
            transform.position = GetMouseWorldPos() + mOffset;
        }

        private void OnMouseDown()
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = transform.position - GetMouseWorldPos();
        }

        private Vector3 GetMouseWorldPos()
        {
            Vector3 mosePoint = Input.mousePosition;
            mosePoint.z = mZCoord;
            var result = Camera.main.ScreenToWorldPoint(mosePoint);
            return result;
        }
    }
}
