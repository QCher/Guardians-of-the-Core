using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "CharactersContainer", menuName = "Scriptable Objects/CharactersContainer")]
public class CharactersContainer : ScriptableObject
{
    public List<CharacterResource> Characters;

    public async UniTask<GameObject> GetRandom()
    {
        var resource = Characters[Random.Range(0, Characters.Count)];
        return await resource.Asset.InstantiateAsync();
    }
    
 
    
}
