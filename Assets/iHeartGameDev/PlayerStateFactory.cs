namespace iHeartGameDev
{
    public class PlayerStateFactory
    {
        private readonly PlayerStateMachine _context;

        public PlayerStateFactory(PlayerStateMachine context)
        {
            _context = context;
        }

        public PlayerBaseState Idle() => new PlayerIdleState(_context, this);
        public PlayerBaseState Walk() => new PlayerWalkState(_context, this);
        public PlayerBaseState Run() => new PlayerRunState(_context, this);
        public PlayerBaseState Jump() => new PlayerJumpState(_context, this);
        public PlayerBaseState Grounded() => new PlayerGroundedState(_context, this);
    }
}
