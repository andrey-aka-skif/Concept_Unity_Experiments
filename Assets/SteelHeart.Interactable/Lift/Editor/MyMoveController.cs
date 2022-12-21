using UnityEngine;

namespace SteelHeart.Interactable
{
    [ExecuteInEditMode]
    public class MyMoveController : MonoBehaviour
    {
        [SerializeField] private Transform _child;

        Vector3 _oldChildLocalPosition;
        //Vector3 _oldChildPosition;

        /*
        private void Start()
        {
            _oldChildLocalPosition = _child.localPosition;
            _oldChildPosition = _child.position;
        }

        private void OnEnable()
        {
            _oldChildLocalPosition = _child.localPosition;
            _oldChildPosition = _child.position;
            print(_oldChildLocalPosition);
            print(_oldChildPosition);
        }
        */

        /*
        private void Update()
        {
            //Vector3 newPosition = _child.position;
            //transform.position = newPosition;
            //_child.position = newPosition;

            //transform.position = _child.position;

            //Vector3 newPosition = _child.position;
            //transform.position = newPosition;
            //_child.position = newPosition;

            //transform.position = _child.position - _child.localPosition;

            Vector3 deltaLocal = _child.localPosition - _oldChildLocalPosition;
            Vector3 delta = _child.position - _oldChildPosition;

            Debug.Log(string.Format("{0} / {1}", deltaLocal, delta));

            _child.localPosition -= deltaLocal;
            transform.position += deltaLocal;

            _oldChildLocalPosition = _child.localPosition;
            _oldChildPosition = _child.position;
        }
        */

        /*
        private void Update()
        {
            transform.position = _child.position - _child.localPosition;

            print(_child.position - _child.localPosition);
        }
        */

        private void OnEnable()
        {
            _oldChildLocalPosition = _child.localPosition;
        }

        private void Update()
        {
            Vector3 delta = _child.localPosition - _oldChildLocalPosition;
            transform.position += delta;
            _child.localPosition -= delta;

            _oldChildLocalPosition = _child.localPosition;
        }
    }

    /*
    [ExecuteInEditMode]
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private Transform _child;

        private void Update()
        {
            transform.position = _child.position;
        }
    }
    */
}
