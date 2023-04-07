using System;

namespace Game.FSMCore.Transitions
{
public abstract class BaseTransition : IDisposable
{
    public abstract bool Decide();
    
    public abstract void Transit();
    
    public virtual void Dispose() { }
}
}