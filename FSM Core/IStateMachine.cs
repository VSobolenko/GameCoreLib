using System;
using Game.FSMCore.States;

namespace Game.FSMCore
{
public interface IStateMachine
{
    BaseState ActiveState { get; }
    BaseState PreviousState { get; }
    event Action<BaseState> OnStateChange;
    void SwitchState(BaseState newState);
}
}