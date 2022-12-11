using UnityEngine;

namespace GroundCheck
{
    /// <summary>
    /// Компонент, регистрирующий поверхность в пределах указанного расстояния
    /// </summary>
    public class SurfaceSensor : MonoBehaviour
    {
        private float _checkDistance = 1.0f;
        private LayerMask _checkLayerMask = ~0;

        public void Init(float checkDistance, LayerMask checkLayerMask)
        {
            _checkDistance = checkDistance;
            _checkLayerMask = checkLayerMask;
        }

        public bool IsGrounded =>
            Physics.Raycast(
                transform.position,
                (-1) * transform.up,
                _checkDistance,
                _checkLayerMask);
    }
}
