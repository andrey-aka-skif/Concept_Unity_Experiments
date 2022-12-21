using UnityEngine;

namespace SteelHeart.Interactable
{
    [ExecuteInEditMode]
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private WithMove _withMove1;
        [SerializeField] private WithMove _withMove2;

        //public void OnMove(WithMove src)
        //{
        //    if (src == _withMove1)
        //        CheckMove1();

        //    if (src == _withMove2)
        //        CheckMove2();
        //}

        //private void CheckMove2()
        //{
        //    Vector3 newPosition = _withMove2.transform.position;
        //    transform.position = newPosition;
        //    //_withMove2.transform.position = newPosition;

        //    _withMove2.MoveTo(newPosition);

        //    print(newPosition);
        //}

        private void Update()
        {
            Vector3 newPosition = _withMove2.transform.position;
            transform.position = newPosition;
            _withMove2.transform.position = newPosition;
        }

        private void CheckMove1() { }
    }
}
