using UnityEngine;

namespace Assets.NavMesh
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Sheep _sheep;
        [SerializeField] Vector3 _size;

        private IWolf _wolf;
        private SpawnPositionRandomizer _randomizer;

        public void Setup(IWolf wolf)
        {
            _wolf = wolf;
            _randomizer = new SpawnPositionRandomizer(transform.position, _size);
        }

        public void Spawn(Transform root, int count = 3)
        {
            for (int i = 0; i < count; i++)
            {
                Sheep sheep = Instantiate(_sheep);
                sheep.transform.SetParent(root.transform, false);
                sheep.transform.position = _randomizer.GetNextPosition();
                sheep.Setup(_wolf);
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 1, 0.5f);
            Gizmos.DrawWireCube(transform.position, _size);
        }
#endif
    }
}
