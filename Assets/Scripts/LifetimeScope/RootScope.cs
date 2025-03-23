using UnityEngine;
using VContainer;
using VContainer.Unity;
using VContainer.Util;

public class RootScope : LifetimeScope
{
    [SerializeField] private CharactersContainer _charactersContainer;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ILogger, LogService>(Lifetime.Singleton);
        builder.RegisterInstance(_charactersContainer);
    }
}