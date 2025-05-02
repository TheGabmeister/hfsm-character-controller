using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerLightLandingState : PlayerLandingState
    {
        public PlayerLightLandingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void OnEnter()
        {
            stateMachine.ReusableData.MovementSpeedModifier = 0;

            base.OnEnter();

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StationaryForce;

            ResetVelocity();
        }

        public override void OnLogic()
        {
            base.OnLogic();

            if (stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                return;
            }

            OnMove();
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

        public override void OnAnimationTransitionEvent()
        {
            stateMachine.RequestStateChange("IdlingState");
        }
    }
}