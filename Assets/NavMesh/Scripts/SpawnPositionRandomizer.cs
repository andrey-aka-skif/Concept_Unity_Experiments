using UnityEngine;

namespace Assets.NavMesh
{
    public class SpawnPositionRandomizer
    {
        private readonly float _xFrom;
        private readonly float _xTo;
        private readonly float _yFrom;
        private readonly float _yTo;
        private readonly float _zFrom;
        private readonly float _zTo;
        private readonly System.Random _random;

        public SpawnPositionRandomizer(Vector3 position, Vector3 size)
        {
            _xFrom = position.x - size.x / 2;
            _xTo = position.x + size.x / 2;
            _yFrom = position.y - size.y / 2;
            _yTo = position.y + size.y / 2;
            _zFrom = position.z - size.z / 2;
            _zTo = position.z + size.z / 2;
            _random = new System.Random();
        }

        public Vector3 GetNextPosition()
        {
            return new Vector3((float)(_random.NextDouble() * (_xTo - _xFrom) + _xFrom),
                               (float)(_random.NextDouble() * (_yTo - _yFrom) + _yFrom),
                               (float)(_random.NextDouble() * (_zTo - _zFrom) + _zFrom));
        }
    }
}
