using UnityEngine;

namespace SteelHeart.Interactable
{
    [ExecuteInEditMode]
    public class LiftToolTip : MonoBehaviour
    {
        [SerializeField] private Color _color = Color.blue;
        [SerializeField] private bool _wireframe = false;
        [SerializeField] private Vector3 _rect = new(.5f, .5f, .5f);

        void OnDrawGizmos()
        {
            Gizmos.color = _color;

            if (_wireframe)
                Gizmos.DrawWireCube(transform.position, _rect);
            else
                Gizmos.DrawCube(transform.position, _rect);
        }
    }
}
