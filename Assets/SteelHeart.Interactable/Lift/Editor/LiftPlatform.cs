using UnityEngine;

namespace SteelHeart.Interactable
{
    [ExecuteInEditMode]
    public class LiftPlatform : MonoBehaviour, ILiftComponent
    {
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
            //if (transform.hasChanged)
            //{
            //    Lift.OnChildrenTransformChange(this);
            //    transform.hasChanged = false;
            //}
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, new Vector3(1, .1f, 1));
        }
    }
}
