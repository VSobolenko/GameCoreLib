using System;

namespace Game.FSMCore.States
{
public abstract class BaseState : IDisposable
{
    public abstract StateType Type { get; }
    
    public abstract bool IsActiveState { get; }
    
    public void UpdateState()
    {
        try
        {
            OnStateUpdated();
        }
        catch (Exception e)
        {
            Log.Exception($"[OnStateFinished] {e.Message}");
        }
    }
    
    protected virtual void OnStateUpdated() { }

    public abstract void ForceFinish();
    
    public virtual void Dispose() { }
    
#if DEVELOPMENT_BUILD
    
    protected static int stateCounter;
    
#endif
    
}
}