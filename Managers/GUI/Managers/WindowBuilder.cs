using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.GUI.Windows.Factories;
using UnityEngine;

namespace Game.GUI.Windows.Managers
{
internal class WindowBuilder : IDisposable, IEnumerable<WindowProperties>
{
    public int Count => _windows.Count;

    private readonly List<WindowProperties> _windows = new(8);
    private readonly IWindowFactory _windowFactory;
    private readonly Transform _root;

    public WindowBuilder(IWindowFactory windowFactory, Transform root)
    {
        _windowFactory = windowFactory;
        _root = root;
    }

    public void Dispose()
    {
        for (var i = _windows.Count - 1; i >= 0; i--)
        {
            try
            {
                CloseWindow(i);
            }
            catch (Exception e)
            {
                Log.Exception($"Error inside close: {e.Message}");
            }
        }

        _windows.Clear();
    }

    public WindowProperties OpenWindow<TMediator>(Action<TMediator> initWindow = null)
        where TMediator : class, IMediator
    {
        if (_windowFactory.TryCreateWindow<TMediator>(_root, out var mediator, out var window) == false)
            return default;

        try
        {
            mediator.SetActive(true);
            mediator.OnInitialize();
            mediator.OnFocus();
            initWindow?.Invoke(mediator);
        }
        catch (Exception e)
        {
            Log.Exception(e.Message);
        }

        var windowData = new WindowProperties
        {
            mediator = mediator,
            rectTransform = window.GetComponent<RectTransform>(),
            canvasGroup = window.GetComponent<CanvasGroup>(),
        };

        _windows.Add(windowData);

        return windowData;
    }

    public void CloseWindow(int index)
    {
        if (_windows.ElementAtOrDefault(index)?.mediator == null)
            return;

        try
        {
            _windows[index].mediator.OnUnfocused();
            _windows[index].mediator.OnDestroy();
            _windows[index].mediator.Destroy();

            _windows.RemoveAt(index);

            if (_windows.ElementAtOrDefault(index - 1)?.mediator == null)
                return;
        }
        catch (Exception e)
        {
            Log.Exception(e.Message);
        }

        try
        {
            _windows[index - 1].mediator.SetActive(true);
            _windows[index - 1].mediator.OnFocus();
        }
        catch (Exception e)
        {
            Log.Exception(e.Message);
        }
    }

    public void HideWindow(int index, bool deactivateLastWindow)
    {
        if (_windows.ElementAtOrDefault(index)?.mediator == null)
            return;

        _windows[index].mediator.OnUnfocused();
        if (deactivateLastWindow)
            _windows[index].mediator.SetActive(false);
    }

    public WindowProperties this[int i] => _windows[i];

    IEnumerator<WindowProperties> IEnumerable<WindowProperties>.GetEnumerator() => _windows.GetEnumerator();

    public IEnumerator GetEnumerator() => _windows.GetEnumerator();
}
}