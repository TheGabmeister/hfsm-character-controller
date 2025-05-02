class TestState : PlayerActionState
{
    public TestState()
        : base(needsExitTime: false, isGhostState: false) { }

    public override void Init() { }
    public override void OnEnter() { }
    public override void OnLogic() { }
    public override void OnPhysicsLogic() { }
    public override void OnHandleInput() { }
    public override void OnExit() { }
    public override void OnExitRequest() { }
}
