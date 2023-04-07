using Game.Audio;
using Game.Audio.Managers;
using Zenject;

namespace Game.Installers.Audio
{
public class AudioInstaller : Installer<AudioInstaller>
{
    private const string ResourcesSettingsPath = "Audio/AudioSettings";
    
    public override void InstallBindings()
    {
        Container.Bind<IAudioManager>().To<UnityAudioManager>().AsSingle().NonLazy();
        Container.Bind<AudioSettings>().FromMethod(LoadSettingsFromResources).AsSingle().NonLazy();
    }

    private AudioSettings LoadSettingsFromResources()
    {
        var so = UnityEngine.Resources.Load<AudioSettings>(ResourcesSettingsPath);
        if (so == null)
        {
            Log.Error($"Can't load localization so settings. Path to so: {ResourcesSettingsPath}");

            return default;
        }

        return so;
    }
}
}