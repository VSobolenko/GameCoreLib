namespace Game.GUI.Windows
{
public interface IMediator : IWindowListener
{
    void SetActive(bool value);
    bool IsActive();
    void Destroy();
}
}