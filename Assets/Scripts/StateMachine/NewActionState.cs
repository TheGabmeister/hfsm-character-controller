using UnityHFSM;

public abstract class NewActionState : ActionState
{
    protected NewActionState(bool needsExitTime, bool isGhostState = false)
        : base(needsExitTime, isGhostState)
    {
        AddAction("OnFixedLogic", OnFixedLogic);
    }

    public abstract void OnFixedLogic();
}