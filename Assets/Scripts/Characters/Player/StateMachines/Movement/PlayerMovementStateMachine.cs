using UnityHFSM;

namespace GenshinImpactMovementSystem
{
    public class PlayerMovementStateMachine : UnityHFSM.StateMachine
    {
        public Player Player { get; }
        public PlayerStateReusableData ReusableData { get; }

        public PlayerMovementStateMachine(Player player)
        {
            Player = player;
            ReusableData = new PlayerStateReusableData();

            AddState("IdlingState", new PlayerIdlingState(this));

            AddState("DashingState", new PlayerDashingState(this));

            AddState("WalkingState", new PlayerWalkingState(this));
            AddState("RunningState", new PlayerRunningState(this));
            AddState("SprintingState", new PlayerSprintingState(this));


            AddState("LightStoppingState", new PlayerLightStoppingState(this));
            AddState("MediumStoppingState", new PlayerMediumStoppingState(this));
            AddState("HardStoppingState", new PlayerHardStoppingState(this));

            AddState("LightLandingState", new PlayerLightLandingState(this));
            AddState("RollingState", new PlayerRollingState(this));
            AddState("HardLandingState", new PlayerHardLandingState(this));

            AddState("JumpingState", new PlayerJumpingState(this));
            AddState("FallingState", new PlayerFallingState(this));

            SetStartState("IdlingState");
        }
    }
}