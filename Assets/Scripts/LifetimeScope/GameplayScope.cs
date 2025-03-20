using Gameplay;
using MainMenu;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

public class GameplayScope : LifetimeScope
{
    [SerializeField] Camera _gameplayCamera;
    [SerializeField, Required] private GameplayScreen _gameplayScreen;
    [Scene, SerializeField] private string _navigationSceneName;
    [SerializeField] Placement[] _placements;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_gameplayScreen);
        foreach (var placement in _placements)
        {
            builder.Register<PlacementObject>(Lifetime.Scoped).WithParameter(placement);
        }
        builder.RegisterComponent(_gameplayCamera);
        builder.RegisterEntryPoint<GameplayPresenter>().WithParameter("sceneName", _navigationSceneName);
    }
}
