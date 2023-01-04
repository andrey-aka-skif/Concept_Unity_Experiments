using UnityEngine;

namespace Minefield
{
    internal class Placer
    {
        public static void Place(Transform source, Transform root, Vector2Int array, float shift)
        {
            float x0 = -(array.x - 1) * shift / 2;
            float z0 = -(array.y - 1) * shift / 2;

            for (var x = 0; x < array.x; x++)
            {
                for (var z = 0; z < array.y; z++)
                {
                    Object.Instantiate(source,
                                       new Vector3(x0 + x * shift,
                                                   root.position.y,
                                                   z0 + z * shift),
                                       Quaternion.identity,
                                       root);
                }
            }
        }
    }
}
