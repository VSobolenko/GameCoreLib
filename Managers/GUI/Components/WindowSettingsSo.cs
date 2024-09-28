using System;
using DG.Tweening;
using Game.InternalData;
using UnityEngine;

namespace Game.GUI.Windows
{
[Serializable]
internal class WindowSettings
{
    [Header("Default Transition"), SerializeField] private float transitionMoveDuration = .5f;
    [SerializeField] private Ease moveType = Ease.Linear;

    public float TransitionMoveDuration => transitionMoveDuration;
    public Ease MoveType => moveType;
}

[CreateAssetMenu(fileName = nameof(WindowSettings), menuName = GameData.EditorName +"/Window Settings", order = 3)]
internal class WindowSettingsSo : ScriptableObject
{
    public WindowSettings windowSettings;
}
}