using UnityEngine;

namespace SteelHeart.Interactable
{
    [ExecuteInEditMode]
    public class WithMove : MonoBehaviour
    {
        [SerializeField] private MoveController _controller;

        //public void MoveTo(Vector3 position)
        //{
        //    transform.hasChanged = false;
        //    transform.position = position;
        //    transform.hasChanged = false;
        //}

        //private void Update()
        //{
        //    if (transform.hasChanged)
        //    {
        //        _controller.OnMove(this);
        //    }

        //    transform.hasChanged = false;
        //}
    }
}
