namespace Game.GUI.Windows
{
public interface IWindow
{
    void OnInitialize();
    void OnShow();
    void OnHide();
    void OnDestroy();
}
}