using System;

namespace Game.FSMCore.States
{
public abstract class State<TInput, TOutput> : BaseState
{
    protected IStateMachine stateMachine;
    protected TInput inputData;

    public override bool IsActiveState => stateMachine?.ActiveState == this;

    public void ActiveState(IStateMachine machine, TInput data)
    {
        
#if DEVELOPMENT_BUILD
        
        stateCounter++;
        Log.WriteInfo($"[{stateCounter}]Active state: {GetType().Name}");
        
#endif
        
        inputData = data;
        stateMachine = machine;
        stateMachine?.SwitchState(this);
        OnStateActivated();
    }
    
    public TOutput FinishState()
    {
        try
        {
            return OnStateFinished();
        }
        catch (Exception e)
        {
            Log.Exception($"[OnStateFinished] {e.Message}");
        }
        
        return default;
    }

    public override void ForceFinish()
    {
        FinishState();
    }

    protected virtual void OnStateActivated() { }
    protected abstract TOutput OnStateFinished();
}
}