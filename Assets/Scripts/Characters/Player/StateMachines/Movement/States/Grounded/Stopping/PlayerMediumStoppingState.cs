namespace GenshinImpactMovementSystem
{
    public class PlayerMediumStoppingState : PlayerStoppingState
    {
        public PlayerMediumStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            StartAnimation(stateMachine.Player.AnimationData.MediumStopParameterHash);

            stateMachine.ReusableData.MovementDecelerationForce = groundedData.StopData.MediumDecelerationForce;

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.MediumForce;
        }

        public override void OnExit()
        {
            base.OnExit();

            StopAnimation(stateMachine.Player.AnimationData.MediumStopParameterHash);
        }
    }
}