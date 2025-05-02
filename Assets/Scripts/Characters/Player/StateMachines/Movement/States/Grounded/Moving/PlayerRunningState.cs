using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerRunningState : PlayerMovingState
    {
        private float startTime;

        public PlayerRunningState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void OnEnter()
        {
            stateMachine.ReusableData.MovementSpeedModifier = groundedData.RunData.SpeedModifier;

            base.OnEnter();

            StartAnimation(stateMachine.Player.AnimationData.RunParameterHash);

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.MediumForce;

            startTime = Time.time;
        }

        public override void OnExit()
        {
            base.OnExit();

            StopAnimation(stateMachine.Player.AnimationData.RunParameterHash);
        }

        public override void OnLogic()
        {
            base.OnLogic();

            if (!stateMachine.ReusableData.ShouldWalk)
            {
                return;
            }

            if (Time.time < startTime + groundedData.SprintData.RunToWalkTime)
            {
                return;
            }

            StopRunning();
        }

        private void StopRunning()
        {
            if (stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                stateMachine.RequestStateChange("IdlingState");

                return;
            }

            stateMachine.RequestStateChange("WalkingState");
        }

        protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            base.OnWalkToggleStarted(context);

            stateMachine.RequestStateChange("WalkingState");
        }

        protected override void OnMovementCanceled(InputAction.CallbackContext context)
        {
            stateMachine.RequestStateChange("MediumStoppingState");

            base.OnMovementCanceled(context);
        }
    }
}