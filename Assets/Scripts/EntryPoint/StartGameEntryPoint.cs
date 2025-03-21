using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class StartGameEntryPoint : IInitializable
{
    private readonly IReadOnlyList<PlacementObject> _placements;
    private readonly IObjectResolver _container;
    private readonly GameObject _character;
    
    public StartGameEntryPoint(IReadOnlyList<PlacementObject> placementObjects, IObjectResolver container, GameObject character)
    {
        _placements = placementObjects;
        _container = container;
        _character = character;
    }
    void IInitializable.Initialize()
    {
        foreach (var placement in _placements)
        {
            placement.Object.Place(_container.Instantiate(_character));
        }
    }
}
