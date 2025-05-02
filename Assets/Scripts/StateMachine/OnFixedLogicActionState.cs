using UnityHFSM;

public abstract class OnFixedLogicActionState : ActionState
{
    protected OnFixedLogicActionState(bool needsExitTime, bool isGhostState = false)
        : base(needsExitTime, isGhostState)
    {
        AddAction("OnFixedLogic", OnFixedLogic);
    }

    public abstract void OnFixedLogic();
}