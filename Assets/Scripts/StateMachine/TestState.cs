using UnityHFSM;

class TestState : NewActionState
{
    public TestState()
        : base(needsExitTime: false, isGhostState: false) { }

    public override void Init() { }
    public override void OnEnter() { }
    public override void OnLogic() { }
    public override void OnFixedLogic() { }
    public override void OnExit() { }
    public override void OnExitRequest() { }
}
