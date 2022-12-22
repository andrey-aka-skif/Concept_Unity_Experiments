using UnityEngine;

namespace SteelHeart.Interactable
{
    public class LiftDoor : MonoBehaviour
    {
        [SerializeField] private Lift _lift;
        public void OnDoorsOpen() => _lift.OnDoorsOpen();

        public void OnDoorsClose() => _lift.OnDoorsClose();
    }
}
