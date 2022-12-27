namespace iHeartGameDev
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerStateMachine context, PlayerStateFactory factory)
            : base(context, factory)
        { }

        public override void EnterState()
        {
            // устанавливаем переменные для анимации
            // дергаем не сам Animator, а свойства контекста
            // контекст сам воткнет их в Animator
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void ExitState()
        {
            //
        }

        public override void InitializeSubState()
        {
            throw new System.NotImplementedException();
        }

        public override void CheckSwitchState()
        {
            if (true)
                SwitchState(Factory.Run());
            else
                SwitchState(Factory.Walk());
        }
    }
}
