using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;
using VContainer.Util;

public class BootScope : LifetimeScope
{
    [SerializeField] LoadingScreen _loadingScreen;
    [SerializeField, Scene] private string _sceneName;
    [SerializeField] CharactersContainer _charactersContainer;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_loadingScreen);
        builder.Register<SceneLoader>(Lifetime.Singleton);
        builder.Register<SaveDataService>(Lifetime.Singleton);
        builder.RegisterInstance(_charactersContainer);
        builder.RegisterEntryPoint<LoadSceneEntryPoint>().WithParameter("sceneName", _sceneName);
    }
}