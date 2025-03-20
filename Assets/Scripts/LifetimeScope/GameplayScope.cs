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

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_gameplayScreen);
        builder.RegisterEntryPoint<GameplayPresenter>().WithParameter("sceneName", _navigationSceneName);
    }
}
