using UnityHFSM;

public abstract class PlayerActionState : ActionState
{
    protected PlayerActionState(bool needsExitTime, bool isGhostState = false)
        : base(needsExitTime, isGhostState)
    {
        AddAction("OnPhysicsLogic", OnPhysicsLogic);
        AddAction("OnHandleInput", OnHandleInput);
    }

    public abstract void OnPhysicsLogic();
    public abstract void OnHandleInput();
}