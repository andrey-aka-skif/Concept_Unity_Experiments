using UnityEngine;

namespace SteelHeart.Interactable
{
    [ExecuteInEditMode]
    public class LiftTip : MonoBehaviour, ILiftComponent
    {
        [SerializeField] private Color _color = Color.blue;
        [SerializeField] private Vector3 _rect = new Vector3(.5f, .5f, .5f);

        private Lift _lift;

        private Lift Lift
        {
            get
            {
                if (_lift == null)
                    _lift = GetComponentInParent<Lift>();

                return _lift;
            }
        }

        private void Update()
        {
            if (transform.hasChanged && !Lift.ChangingNow)
                Lift.OnChildrenTransformChange(this);

            transform.hasChanged = false;
        }

        public void MoveTo(Vector3 position)
        {
            transform.hasChanged = false;
            transform.position = position;
            transform.hasChanged = false;

        }

        void OnDrawGizmos()
        {
            Gizmos.color = _color;
            Gizmos.DrawCube(transform.position, _rect);
        }
    }
}
