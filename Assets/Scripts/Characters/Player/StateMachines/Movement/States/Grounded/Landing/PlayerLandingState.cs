namespace GenshinImpactMovementSystem
{
    public class PlayerLandingState : PlayerGroundedState
    {
        public PlayerLandingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            StartAnimation(stateMachine.Player.AnimationData.LandingParameterHash);

            DisableCameraRecentering();
        }

        public override void OnExit()
        {
            base.OnExit();

            StopAnimation(stateMachine.Player.AnimationData.LandingParameterHash);
        }
    }
}