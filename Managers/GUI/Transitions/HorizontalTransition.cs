﻿using System.Threading.Tasks;
using DG.Tweening;
using Game.GUI.Windows.Managers;
using UnityEngine;

namespace Game.GUI.Windows.Transitions
{
internal class HorizontalTransition : IWindowTransition
{
    private readonly WindowSettings _settings;
    private readonly int _width;
    private readonly int _height;

    public HorizontalTransition(WindowSettings settings)
    {
        _settings = settings;
        _width = Screen.width;
        _height = Screen.height;
    }

    public Task Open(WindowProperties windowProperties)
    {
        var completionSource = new TaskCompletionSource<bool>();

        var canvasGroup = windowProperties.canvasGroup;
        var transform = windowProperties.rectTransform;
        canvasGroup.blocksRaycasts = false;

        var activePos = transform.localPosition;
        var startPos = new Vector3(activePos.x + transform.rect.width, activePos.y, activePos.z);

        transform.localPosition = startPos;
        MoveWindow(transform, Vector3.zero, () =>
        {
            canvasGroup.blocksRaycasts = true;
            completionSource.SetResult(true);
        });

        return completionSource.Task;
    }

    public Task Close(WindowProperties windowProperties)
    {
        var completionSource = new TaskCompletionSource<bool>();

        var canvasGroup = windowProperties.canvasGroup;
        var transform = windowProperties.rectTransform;
        var activePos = transform.localPosition;

        canvasGroup.blocksRaycasts = false;
        var targetPosition = new Vector3(activePos.x - transform.rect.width, activePos.y, activePos.z);

        MoveWindow(transform, targetPosition, () =>
        {
            canvasGroup.blocksRaycasts = true;
            completionSource.SetResult(true);
            transform.localPosition = activePos;
        });

        return completionSource.Task;
    }

    private void MoveWindow(RectTransform transform, Vector3 to, TweenCallback completeAction)
    {
        transform.DOLocalMove(to, _settings.TransitionMoveDuration)
                 .SetEase(_settings.MoveType)
                 .OnComplete(completeAction);
    }
}
}