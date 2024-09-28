using System;
using Game.GUI.Windows.Components;
using UnityEngine;

namespace Game.GUI.Windows
{
internal abstract class BaseReactiveMediator<TWindow, TReactive> : IMediator 
    where TWindow : WindowUI 
    where TReactive : struct, Enum
{
    protected readonly TWindow window;
    protected readonly BaseButton<TReactive> reactiveButton;

    protected BaseReactiveMediator(TWindow window, BaseButton<TReactive> reactiveButton)
    {
        this.window = window;
        this.reactiveButton = reactiveButton;
    }

    public virtual void OnInitialize()
    {
        reactiveButton.OnClickButton += ProceedButtonAction;
    }

    public virtual void OnFocus() { }

    public virtual void OnUnfocused() { }

    public virtual void OnDestroy()
    {
        reactiveButton.OnClickButton -= ProceedButtonAction;
    }

    protected virtual void ProceedButtonAction(TReactive action) { }
    
    public void SetActive(bool value) => window.gameObject.SetActive(value);

    public bool IsActive() => window.gameObject.activeInHierarchy;

    public void Destroy() => GameObject.Destroy(window.gameObject);
}
}