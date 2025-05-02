using UnityEngine;

public class PlayerFallingState : PlayerAirborneState
{
    private Vector3 playerPositionOnEnter;

    public PlayerFallingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        StartAnimation(stateMachine.Player.AnimationData.FallParameterHash);

        stateMachine.ReusableData.MovementSpeedModifier = 0f;

        playerPositionOnEnter = stateMachine.Player.transform.position;

        ResetVerticalVelocity();
    }

    public override void OnExit()
    {
        base.OnExit();

        StopAnimation(stateMachine.Player.AnimationData.FallParameterHash);
    }

    public override void OnPhysicsLogic()
    {
        base.OnPhysicsLogic();

        LimitVerticalVelocity();
    }

    private void LimitVerticalVelocity()
    {
        Vector3 playerVerticalVelocity = GetPlayerVerticalVelocity();

        if (playerVerticalVelocity.y >= -airborneData.FallData.FallSpeedLimit)
        {
            return;
        }

        Vector3 limitedVelocityForce = new Vector3(0f, -airborneData.FallData.FallSpeedLimit - playerVerticalVelocity.y, 0f);

        stateMachine.Player.Rigidbody.AddForce(limitedVelocityForce, ForceMode.VelocityChange);
    }

    protected override void ResetSprintState()
    {
    }

    protected override void OnContactWithGround(Collider collider)
    {
        float fallDistance = playerPositionOnEnter.y - stateMachine.Player.transform.position.y;

        if (fallDistance < airborneData.FallData.MinimumDistanceToBeConsideredHardFall)
        {
            stateMachine.RequestStateChange("LightLandingState");

            return;
        }

        if (stateMachine.ReusableData.ShouldWalk && !stateMachine.ReusableData.ShouldSprint || stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            stateMachine.RequestStateChange("HardLandingState");

            return;
        }

        stateMachine.RequestStateChange("RollingState");

    }
}
