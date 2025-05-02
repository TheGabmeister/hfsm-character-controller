using UnityEngine.InputSystem;

public class PlayerHardLandingState : PlayerLandingState
{
    public PlayerHardLandingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void OnEnter()
    {
        stateMachine.ReusableData.MovementSpeedModifier = 0f;

        base.OnEnter();

        StartAnimation(stateMachine.Player.AnimationData.HardLandParameterHash);

        stateMachine.Player.Input.PlayerActions.Movement.Disable();

        ResetVelocity();
    }

    public override void OnExit()
    {
        base.OnExit();

        StopAnimation(stateMachine.Player.AnimationData.HardLandParameterHash);

        stateMachine.Player.Input.PlayerActions.Movement.Enable();
    }

    public override void OnPhysicsLogic()
    {
        base.OnPhysicsLogic();

        if (!IsMovingHorizontally())
        {
            return;
        }

        ResetVelocity();
    }

    public override void OnAnimationExitEvent()
    {
        stateMachine.Player.Input.PlayerActions.Movement.Enable();
    }

    public override void OnAnimationTransitionEvent()
    {
        stateMachine.RequestStateChange("IdlingState");
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        stateMachine.Player.Input.PlayerActions.Movement.started += OnMovementStarted;
    }

    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();

        stateMachine.Player.Input.PlayerActions.Movement.started -= OnMovementStarted;
    }

    private void OnMovementStarted(InputAction.CallbackContext context)
    {
        OnMove();
    }

    protected override void OnMove()
    {
        if (stateMachine.ReusableData.ShouldWalk)
        {
            return;
        }

        stateMachine.RequestStateChange("RunningState");
    }

    protected override void OnJumpStarted(InputAction.CallbackContext context)
    {
    }
}