using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerIdlingState : PlayerGroundedState
    {
        public PlayerIdlingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void OnEnter()
        {
            stateMachine.ReusableData.MovementSpeedModifier = 0f;

            stateMachine.ReusableData.BackwardsCameraRecenteringData = groundedData.IdleData.BackwardsCameraRecenteringData;

            base.OnEnter();

            StartAnimation(stateMachine.Player.AnimationData.IdleParameterHash);

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StationaryForce;

            ResetVelocity();
        }

        public override void OnExit()
        {
            base.OnExit();

            StopAnimation(stateMachine.Player.AnimationData.IdleParameterHash);
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
    }
}