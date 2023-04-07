using System.Threading.Tasks;
using UnityEngine;

namespace Game.GUI.Windows.Transitions
{
public interface IWindowTransition
{
    Task Open(RectTransform transform, CanvasGroup canvasGroup);
    Task Close(RectTransform transform, CanvasGroup canvasGroup);
}
}