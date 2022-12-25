using UnityEngine;

namespace SteelHeart.HFSM
{
    public class LeveledState : StateMachine
    {
        public LeveledState(LiftHFSM lift,
                            float speed,
                            Transform upPoint,
                            Transform downPoint,
                            Transform platform,
                            Animator animator,
                            StatesFactory factory) : base(lift, speed, upPoint, downPoint, platform, animator, factory)
        {
        }

        protected override void OnEnter()
        {
            Debug.Log("LeveledState OnEnter");

            // если есть вызов на другой этаж - едем
            if (_lift.HasCallToUp)
            {
            }

            // если есть вызов на свой этаж - открываем дверь
            if (_lift.HasCallToDown)
            {
            }

            SetSubState(_factory.GetSate<CloseDoorState>());
        }
    }
}
