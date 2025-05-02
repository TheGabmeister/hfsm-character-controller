using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerRollingState : PlayerLandingState
    {
        public PlayerRollingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void OnEnter()
        {
            stateMachine.ReusableData.MovementSpeedModifier = groundedData.RollData.SpeedModifier;

            base.OnEnter();

            StartAnimation(stateMachine.Player.AnimationData.RollParameterHash);

            stateMachine.ReusableData.ShouldSprint = false;
        }

        public override void OnExit()
        {
            base.OnExit();

            StopAnimation(stateMachine.Player.AnimationData.RollParameterHash);
        }

        public override void OnPhysicsLogic()
        {
            base.OnPhysicsLogic();

            if (stateMachine.ReusableData.MovementInput != Vector2.zero)
            {
                return;
            }

            RotateTowardsTargetRotation();
        }

        public override void OnAnimationTransitionEvent()
        {
            if (stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                stateMachine.RequestStateChange("MediumStoppingState");

                return;
            }

            OnMove();
        }

        protected override void OnJumpStarted(InputAction.CallbackContext context)
        {
        }
    }
}