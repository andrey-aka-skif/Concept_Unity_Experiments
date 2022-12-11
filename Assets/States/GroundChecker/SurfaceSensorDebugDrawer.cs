using UnityEngine;

namespace GroundCheck
{
#if UNITY_EDITOR
    /// <summary>
    /// Компонент, отображающий направление и результат работы регистратора поверхности
    /// (работает только в редакторе)
    /// </summary>
    [RequireComponent(typeof(SurfaceSensor))]
    public class SurfaceSensorDebugDrawer : MonoBehaviour
    {
        private SurfaceSensor _sensor;

        private Color _groundHitColor = Color.green;
        private Color _groundMissColor = Color.red;

        public void Init(Color groundHitColor, Color groundMissColor)
        {
            _groundHitColor = groundHitColor;
            _groundMissColor = groundMissColor;
        }

        private SurfaceSensor Sensor
        {
            get
            {
                if(_sensor == null)
                    _sensor = GetComponent<SurfaceSensor>();

                return _sensor;
            }
        }

        private void OnDrawGizmos()
        {
            if (Sensor.IsGrounded)
                Debug.DrawRay(transform.position, (-1) * transform.up, _groundHitColor);
            else
                Debug.DrawRay(transform.position, (-1) * transform.up, _groundMissColor);
        }
    }
#endif
}
