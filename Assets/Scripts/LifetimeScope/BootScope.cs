using NaughtyAttributes;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using VContainer.Util;

public class BootScope : LifetimeScope
{
    [SerializeField] LoadingScreen _loadingScreen;
    [SerializeField, Scene] private string _sceneName;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_loadingScreen);
        builder.Register<SceneLoader>(Lifetime.Singleton);
        builder.RegisterEntryPoint<LoadSceneEntryPoint>().WithParameter("sceneName", _sceneName);
    }
}