using Gameplay;
using NaughtyAttributes;
using UnityEngine;
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
        foreach (var placement in _placements)
        {
            builder.RegisterEntryPoint<PlacementObject>(Lifetime.Scoped).AsSelf().WithParameter(placement);
        }
        
        builder.UseComponents(componentsBuilder =>
        {
            componentsBuilder.AddInstance(_gameplayScreen);
            componentsBuilder.AddInstance(_gameplayCamera);
        });
        
        // builder.RegisterFactory<BogusController>(container => // container is an IObjectResolver
        // {
        //     var dependency = container.Resolve<CharactersContainer>(); // Resolve per scope
        //     return () => container.Instantiate(dependency); // Execute per factory invocation
        // }, Lifetime.Scoped);
        
        builder.UseEntryPoints(pointsBuilder =>
        {
            pointsBuilder.Add<GameplayPresenter>().WithParameter("sceneName", _navigationSceneName);
            pointsBuilder.Add<StartGameEntryPoint>();
        });
    }
}
