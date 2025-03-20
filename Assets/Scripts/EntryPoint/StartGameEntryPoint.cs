using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class StartGameEntryPoint : IInitializable
{
    readonly IReadOnlyList<PlacementObject> _placements;
    private readonly GameObject _character;
    
    public StartGameEntryPoint(IReadOnlyList<PlacementObject> placementObjects, GameObject character)
    {
        _placements = placementObjects;
        _character = character;
    }
    void IInitializable.Initialize()
    {
        foreach (var placement in _placements)
        {
            placement.Object.Place(GameObject.Instantiate(_character));
        }
    }
}
