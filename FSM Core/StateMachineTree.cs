using System;
using System.Collections.Generic;
using System.Linq;
using Game.FSMCore.Transitions;

namespace Game.FSMCore
{
public class StateMachineTree
{
    private List<TransitionData> _transitions = new(5);

    public void UpdateTree(IStateMachine stateMachine)
    {
        foreach (var transitionData in _transitions)
        {
            try
            {
                if (transitionData.transition.Decide() == false) 
                    continue;
                
                transitionData.transition.Transit();
                return;
            }
            catch (Exception e)
            {
                Log.Exception($"[OnStateFinished] {e.Message}");
            }
        }
    }
    
    public void AddTransition(BaseTransition baseTransition, int priority = 0)
    {
        try
        {
            _transitions.Add(new TransitionData
            {
                transition = baseTransition,
                priority = priority,
            });

            _transitions = _transitions.OrderByDescending(x => x.priority).ToList();
        }
        catch (Exception e)
        {
            Log.Exception($"[OnStateFinished] {e.Message}");
        }
    }

    public void AddTransition(params BaseTransition[] baseTransition)
    {
        try
        {
            foreach (var transition in baseTransition)
            {
                _transitions.Add(new TransitionData
                {
                    transition = transition,
                    priority = 0,
                });
            }
        
            _transitions = _transitions.OrderByDescending(x => x.priority).ToList();
        }
        catch (Exception e)
        {
            Log.Exception($"[OnStateFinished] {e.Message}");
        }
    }
    
    public void RemoveTransition(BaseTransition baseTransition)
    {
        try
        {
            var transitionData = _transitions.FirstOrDefault(x => x.transition == baseTransition);
            if (transitionData.Equals(default) || transitionData.transition == null)
            {
                Log.WriteWarning($"Can't remove transition from tree: Transition={baseTransition}");
                return;
            }

            _transitions.Remove(transitionData);
        }
        catch (Exception e)
        {
            Log.Exception($"[OnStateFinished] {e.Message}");
        }
    }

    public BaseTransition this[int index] => _transitions[index].transition;

    public TTransition GetTransition<TTransition>() where TTransition : BaseTransition
    {
        foreach (var transitionData in _transitions)
        {
            if (transitionData.transition.GetType() == typeof(TTransition))
            {
                return transitionData.transition as TTransition;
            }
        }

        return default;
    }

    public void DisposeMachine()
    {
        foreach (var transitionData in _transitions)
        {
            try
            {
                transitionData.transition.Dispose();
            }
            catch (Exception e)
            {
                Log.Exception($"[OnStateFinished] {e.Message}");
            }
        }
    }
}

internal struct TransitionData
{
    public BaseTransition transition;
    public int priority;
}
}