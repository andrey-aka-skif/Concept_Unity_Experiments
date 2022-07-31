using UnityEngine;

namespace Assets.NavMesh
{
    public class AggregateRoot : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Wolf _wolf;
        [SerializeField] private Transform _sheepsRoot;
        [SerializeField] private int _sheepsCount;

        private void Awake()
        {
            _spawner.Setup(_wolf);

            _spawner.Spawn(_sheepsRoot, _sheepsCount);
        }
    }
}
