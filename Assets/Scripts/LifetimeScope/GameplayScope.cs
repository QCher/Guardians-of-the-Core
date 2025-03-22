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
            builder.Register<PlacementObject>(Lifetime.Scoped).WithParameter(placement);
        }
        
        builder.UseComponents(componentsBuilder =>
        {
            componentsBuilder.AddInstance(_gameplayScreen);
            componentsBuilder.AddInstance(_gameplayCamera);
        });
        
        builder.UseEntryPoints(pointsBuilder =>
        {
            pointsBuilder.Add<GameplayPresenter>().WithParameter("sceneName", _navigationSceneName);
            //pointsBuilder.Add<StartGameEntryPoint>().WithParameter(_character);
        });
        
        builder.RegisterFactory<BogusController>(container => // container is an IObjectResolver
        {
            var dependency = container.Resolve<BogusController>(); // Resolve per scope
            return () => container.Instantiate(dependency); // Execute per factory invocation
        }, Lifetime.Scoped);
    }
}
