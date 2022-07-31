using UnityEngine;

namespace Assets.NavMesh
{
    public class Wolf : MonoBehaviour, IWolf
    {
        public Vector3 Position => transform.position;

        public void Setup()
        {

        }
    }
}
