using MainMenu;
using NaughtyAttributes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MainMenuLifetimeScope : LifetimeScope
{
    [SerializeField, Required] private MainMenuScreen _mainMenuScreen;
    [Scene, SerializeField] private string _nextSceneName;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_mainMenuScreen);
        builder.RegisterEntryPoint<MainMenuPresenter>().WithParameter("sceneName", _nextSceneName);
    }
}
