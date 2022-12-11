using UnityEngine;

namespace GroundCheck
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private float _checkDistance = 0.2f;
        [SerializeField] private LayerMask _checkLayerMask = ~0;

#if UNITY_EDITOR
        [Header("Debug.DrawRay")]
        [SerializeField] private Color _groundHitColor = Color.green;
        [SerializeField] private Color _groundMissColor = Color.red;
#endif

        private SurfaceSensor[] _sensors;

        public bool IsGrounded
        {
            get
            {
                foreach (var sensor in _sensors)
                {
                    if (sensor.IsGrounded)
                        return true;
                }
                return false;
            }
        }

        private void Start()
        {
            _sensors = GetComponentsInChildren<SurfaceSensor>();

            foreach (var sensor in _sensors)
                sensor.Init(_checkDistance, _checkLayerMask);

#if UNITY_EDITOR
            SurfaceSensorDebugDrawer[] drawers = GetComponentsInChildren<SurfaceSensorDebugDrawer>();
            foreach (var drawer in drawers)
                drawer.Init(_groundHitColor, _groundMissColor);
#endif
        }
    }
}
