public class PlayerHardStoppingState : PlayerStoppingState
{
    public PlayerHardStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        StartAnimation(stateMachine.Player.AnimationData.HardStopParameterHash);

        stateMachine.ReusableData.MovementDecelerationForce = groundedData.StopData.HardDecelerationForce;

        stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StrongForce;
    }

    public override void OnExit()
    {
        base.OnExit();

        StopAnimation(stateMachine.Player.AnimationData.HardStopParameterHash);
    }

    protected override void OnMove()
    {
        if (stateMachine.ReusableData.ShouldWalk)
        {
            return;
        }

        stateMachine.RequestStateChange("RunningState");
    }
}