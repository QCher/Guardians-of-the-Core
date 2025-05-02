using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using IInitializable = VContainer.Unity.IInitializable;

public class StartGameEntryPoint : IAsyncStartable 
{
    private readonly IReadOnlyList<PlacementObject> _placements;
    //[TODO] ADD RESOURCE LOADING ON  CONTEXT CREATION WITH LOADING SCREEN
    //*TODO ADD RESOURCE INSTANTIATION
    //*TODO ADD Instance DESTROY AND RELEASE RESOURCE
    //?*TODO IS IT NEW RESOURCE PROVIDER FOR RELEASE RESOURCE
    private readonly CharactersContainer _charactersContainer;
    
    
    public StartGameEntryPoint(IReadOnlyList<PlacementObject> placementObjects, CharactersContainer charactersContainer)
    {
        _placements = placementObjects;
        _charactersContainer =  charactersContainer;
    }

    [UsedImplicitly]
    async UniTask IAsyncStartable.StartAsync(CancellationToken cancellation = new CancellationToken())
    {
        foreach (var placement in _placements)
        {
            var character = await _charactersContainer.GetRandom();
            if(character == null) return;//TODO!: LOGS AND HANDLING ERRORS
            //var instance = GameObject.Instantiate(character);
            //*TODO MOVE INSTANCE TO GAMEPLAY SCENE
            placement.Object.Place(character);
        }
    }
}
