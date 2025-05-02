using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerAirborneState : PlayerMovementState
    {
        public PlayerAirborneState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            StartAnimation(stateMachine.Player.AnimationData.AirborneParameterHash);

            ResetSprintState();
        }

        public override void OnExit()
        {
            base.OnExit();

            StopAnimation(stateMachine.Player.AnimationData.AirborneParameterHash);
        }

        protected virtual void ResetSprintState()
        {
            stateMachine.ReusableData.ShouldSprint = false;
        }

        protected override void OnContactWithGround(Collider collider)
        {
            stateMachine.RequestStateChange("LightLandingState");
        }
    }
}