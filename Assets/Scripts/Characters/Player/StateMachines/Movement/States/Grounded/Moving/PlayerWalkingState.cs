using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerWalkingState : PlayerMovingState
    {
        public PlayerWalkingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void OnEnter()
        {
            stateMachine.ReusableData.MovementSpeedModifier = groundedData.WalkData.SpeedModifier;

            stateMachine.ReusableData.BackwardsCameraRecenteringData = groundedData.WalkData.BackwardsCameraRecenteringData;

            base.OnEnter();

            StartAnimation(stateMachine.Player.AnimationData.WalkParameterHash);

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.WeakForce;
        }

        public override void OnExit()
        {
            base.OnExit();

            StopAnimation(stateMachine.Player.AnimationData.WalkParameterHash);

            SetBaseCameraRecenteringData();
        }

        protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            base.OnWalkToggleStarted(context);

            stateMachine.RequestStateChange("RunningState");
        }

        protected override void OnMovementCanceled(InputAction.CallbackContext context)
        {
            stateMachine.RequestStateChange("LightStoppingState");

            base.OnMovementCanceled(context);
        }
    }
}