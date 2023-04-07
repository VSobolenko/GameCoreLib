using Game.Shops;
using UnityEngine;
using Zenject;

namespace Game.Installers.Shops
{
public class ShopInstaller : Installer<ShopInstaller>
{
    private const string ResourcesSettingsPath = "Shop/ProductsConfig";
    
    public override void InstallBindings()
    {
        Container.Bind<IShopManager>().To<IAPShopManager>().AsSingle().NonLazy();
        Container.Bind<GameProduct[]>().FromMethod(LoadProductsFromResources).WhenInjectedInto<IShopManager>();
    }

    private GameProduct[] LoadProductsFromResources()
    {
        var so = Resources.Load<ProductsSettingsCollections>(ResourcesSettingsPath);
        if (so == null)
        {
            Log.Error($"Can't load localization so settings. Path to so: {ResourcesSettingsPath}");

            return default;
        }

        return so.products;
    }
}
}