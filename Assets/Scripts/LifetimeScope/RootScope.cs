using UnityEngine;
using VContainer;
using VContainer.Unity;
using VContainer.Util;

public class RootScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ILogger, LogService>(Lifetime.Singleton);
        builder.Register<SceneLoader>(Lifetime.Singleton);
    }
}