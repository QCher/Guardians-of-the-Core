using System.Collections.Generic;
using System.Linq;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "AssetContainerSchema", menuName = "Scriptable Objects/AssetContainerSchema")]
public class AssetContainerSchema : AddressableAssetGroupSchema
{
    public CharactersContainer Container;

    public void UpdateContainer()
    {
        // Container.Characters.Clear();
        // foreach (var entry in Group.entries)
        // {
        //     var name = entry.AssetPath.Split("/").Last().Split(".").First();
        //     Container.Characters.Add(new CharacterResource(){Id = name, Asset =  new AssetReference()
        //     {
        //         Asset = entry.MainAsset
        //     }});
        // }
    }
}
