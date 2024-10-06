using Game.Ads.Managers;

namespace Game.Ads.Installers
{
public class AdsInstaller
{
    public static IAdsManager Applovin(AdDetails details) => new ApplovinAdManager(details);
}
}