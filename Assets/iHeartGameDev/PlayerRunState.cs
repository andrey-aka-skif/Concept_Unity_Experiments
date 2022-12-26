namespace iHeartGameDev
{
    public class PlayerRunState : PlayerBaseState
    {
        public PlayerRunState(PlayerStateMachine context, PlayerStateFactory factory)
            : base(context, factory)
        {
        }

        public override void EnterState()
        {
            // устанавливаем переменные для анимации
            // дергаем не сам Animator, а свойства контекста
            // контекст сам воткнет их в Animator

            // также здесь обнуляются ветора направлений перемещения
        }

        public override void UpdateState()
        {
            CheckSwitchState();

            // также здесь устанавливаются вектора перемещения на основе Input
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }

        public override void InitializeSubState()
        {
            throw new System.NotImplementedException();
        }

        public override void CheckSwitchState()
        {
            if (true)
                SwitchState(Factory.Idle());
            else
                SwitchState(Factory.Walk());
        }
    }
}
