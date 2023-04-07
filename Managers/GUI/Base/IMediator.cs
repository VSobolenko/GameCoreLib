namespace Game.GUI.Windows
{
public interface IMediator : IWindow
{
    void SetActive(bool value);
    bool IsActive();
    void Destroy();
}
}