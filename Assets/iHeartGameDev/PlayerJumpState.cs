namespace iHeartGameDev
{
    public class PlayerJumpState : PlayerBaseState
    {
        public PlayerJumpState(PlayerStateMachine context, PlayerStateFactory factory)
            : base(context, factory)
        {
        }

        public override void EnterState()
        {
            // проверяем что-нибудь, что нужно проверить
            // например, нажаты ли какие-то кнопки
        }

        public override void UpdateState()
        {
            //
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
            // здесь проверка на касание земли
            // обращение к контексту
            // Если коснулись, то переходим в GroundedState
            SwitchState(Factory.Grounded());
        }
    }
}
