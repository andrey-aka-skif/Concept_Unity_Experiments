using UnityEngine;
using UnityEngine.AI;

namespace Assets.NavMesh
{
    public abstract class BaseState
    {
        protected readonly Sheep _sheep;
        protected readonly IWolf _wolf;
        protected readonly NavMeshAgent _navMeshAgent;
        protected readonly IStateSwitcher _stateSwitcher;

        protected BaseState(Sheep sheep,
                            IWolf wolf,
                            NavMeshAgent navMeshAgent,
                            IStateSwitcher stateSwitcher)
        {
            _sheep = sheep;
            _wolf = wolf;
            _navMeshAgent = navMeshAgent;
            _stateSwitcher = stateSwitcher;
        }

        public virtual void Start() { }
        public virtual void Stop() { }

        public abstract void Update();

        protected Vector3 _destination;

        protected Vector3 GetNextRndPosition(float distance)
        {
            const float from = 0;
            const float to = 180;

            Vector3 direction = Vector3.forward;

            var random = new System.Random();
            float angle = (float)(random.NextDouble() * (to - from) + from);

            direction = Quaternion.Euler(0, angle, 0) * direction;

            return _sheep.Position + direction * distance;
        }

        protected Vector3 GetNextRndPositionSafely(float distance)
        {
            //Debug.Log("Ищем путь");
            const int limit = 25;
            Vector3 destination = Vector3.zero;
            int counter = 0;

            while (!TryGetNextRndPosition(out destination, _sheep.CalmDistance))
            {
                counter++;
                if (counter > limit)
                {
                    //throw new System.OverflowException();
                    //Debug.Log(_sheep.Position);
                    return _sheep.Position;
                }
            }

            //Debug.Log(destination);
            return destination;
        }

        protected bool TryGetNextRndPosition(out Vector3 position, float distance = 1.0f)
        {
            const float from = 1;
            const float to = 359;

            Vector3 direction = Vector3.forward;

            var random = new System.Random();
            float angle = (float)(random.NextDouble() * (to - from) + from);

            Debug.Log(angle);

            direction = Quaternion.Euler(0, angle, 0) * direction;

            position = _sheep.Position + direction * distance;

            return CanWalkTo(position);
        }

        protected bool CanWalkTo(Vector3 destination)
        {
            var path = new NavMeshPath();
            UnityEngine.AI.NavMesh.CalculatePath(_sheep.Position,
                                                 destination,
                                                 UnityEngine.AI.NavMesh.AllAreas,
                                                 path);
            return path.status == NavMeshPathStatus.PathComplete;
        }

        /*
        protected bool IsPathCompleted()
        {
            const float eps = 0.1f;

            return (_destination - _sheep.Position).magnitude < eps;
        }
        */
    }
}
