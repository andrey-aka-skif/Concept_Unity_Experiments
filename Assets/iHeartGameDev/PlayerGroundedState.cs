namespace iHeartGameDev
{
    public class PlayerGroundedState : PlayerBaseState
    {
        public PlayerGroundedState(PlayerStateMachine context, PlayerStateFactory factory)
            : base(context, factory)
        {
            IsRootState = true;
            InitializeSubState();
        }

        public override void EnterState()
        {
            //throw new System.NotImplementedException();
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
            // здесь делаются проверки
            // и если нужно, делается переход
            if (true && true)
                SetSubState(Factory.Idle());
            else if (true && false)
                SetSubState(Factory.Walk());
            else
                SetSubState(Factory.Run());

        }

        public override void CheckSwitchState()
        {
            // проверяем условия для перехода в другое состояние
            // если нужно, то переходим
            SwitchState(Factory.Jump());
        }
    }
}
