using UnityEngine;

namespace SteelHeart.Interactable
{
    [ExecuteInEditMode]
    public class Lift : MonoBehaviour
    {
        [SerializeField] private bool _lockChildControl;

        [SerializeField] private LiftTip _upTip;
        [SerializeField] private LiftTip _downTip;
        [SerializeField] private LiftPlatform _platform;

        [SerializeField] private Color _gigmosColor = Color.yellow;

        public bool ChangingNow { get; private set; }

        public void OnChildrenTransformChange(ILiftComponent component)
        {
            if (ChangingNow)
                return;

            if (component is LiftTip tip)
            {
                if (tip == _upTip)
                    CheckTipUpPosition();

                if (tip == _downTip)
                    CheckTipDownPosition();
            }

            if (component is LiftPlatform platform)
            {
                if (platform == _platform)
                    CheckPlatformPosition();
            }
        }

        private void CheckTipUpPosition()
        {
            ChangingNow = true;

            if (_lockChildControl)
            {
                _upTip.transform.position = new Vector3(transform.position.x,
                                                        _upTip.transform.position.y,
                                                        transform.position.z);

                if (_upTip.transform.position.y < transform.position.y)
                    _upTip.transform.position = transform.position;

                if (_upTip.transform.position.y < _platform.transform.position.y)
                    _platform.transform.position = _upTip.transform.position;
            }
            else
            {
            }

            ChangingNow = false;
        }

        private void CheckTipDownPosition()
        {
            ChangingNow = true;

            if (_lockChildControl)
            {
                _downTip.transform.position = transform.position;
            }
            else
            {
                Vector3 newPosition = _downTip.transform.position;
                transform.position = newPosition;
                _downTip.transform.position = newPosition;
            }

            ChangingNow = false;
        }

        private void CheckPlatformPosition()
        {
            ChangingNow = true;

            if (_lockChildControl)
            {
                _platform.transform.position = new Vector3(transform.position.x,
                                                        _platform.transform.position.y,
                                                        transform.position.z);

                if (_platform.transform.position.y < transform.position.y)
                    _platform.transform.position = transform.position;

                if (_platform.transform.position.y > _upTip.transform.position.y)
                    _platform.transform.position = _upTip.transform.position;

            }
            else
            {

            }

            ChangingNow = false;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = _gigmosColor;

            Vector3 tipsCenter = (_upTip.transform.position + _downTip.transform.position) / 2;
            float gizmosHeight = (_upTip.transform.position - _downTip.transform.position).magnitude;

            Gizmos.DrawWireCube(tipsCenter, new Vector3(1, gizmosHeight, 1));
        }
    }
}
