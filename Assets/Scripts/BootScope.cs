using NaughtyAttributes;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using VContainer.Util;

public class BootScope : LifetimeScope
{
    [SerializeField, Scene] private string _sceneName;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<SceneLoader>(Lifetime.Singleton);
        builder.RegisterEntryPoint<LoadSceneEntryPoint>().WithParameter("sceneName", _sceneName);
    }
}