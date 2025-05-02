using UnityEngine.InputSystem;

public class PlayerStoppingState : PlayerGroundedState
{
    public PlayerStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void OnEnter()
    {
        stateMachine.ReusableData.MovementSpeedModifier = 0f;

        SetBaseCameraRecenteringData();

        base.OnEnter();

        StartAnimation(stateMachine.Player.AnimationData.StoppingParameterHash);
    }

    public override void OnExit()
    {
        base.OnExit();

        StopAnimation(stateMachine.Player.AnimationData.StoppingParameterHash);
    }

    public override void OnPhysicsLogic()
    {
        base.OnPhysicsLogic();

        RotateTowardsTargetRotation();

        if (!IsMovingHorizontally())
        {
            return;
        }

        DecelerateHorizontally();
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
}
