namespace GenshinImpactMovementSystem
{
    public class PlayerMovingState : PlayerGroundedState
    {
        public PlayerMovingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            StartAnimation(stateMachine.Player.AnimationData.MovingParameterHash);
        }

        public override void OnExit()
        {
            base.OnExit();

            StopAnimation(stateMachine.Player.AnimationData.MovingParameterHash);
        }
    }
}