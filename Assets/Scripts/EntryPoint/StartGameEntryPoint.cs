using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using IInitializable = VContainer.Unity.IInitializable;

public class StartGameEntryPoint : IInitializable
{
    private readonly IReadOnlyList<PlacementObject> _placements;
    private readonly Func<BogusController> _factory;
    
    
    public StartGameEntryPoint(IReadOnlyList<PlacementObject> placementObjects,  Func<BogusController> factory)
    {
        _placements = placementObjects;
        _factory = factory;
    }
    void IInitializable.Initialize()
    {
        foreach (var placement in _placements)
        {
            placement.Object.Place(_factory.Invoke().gameObject);
        }
    }
}
