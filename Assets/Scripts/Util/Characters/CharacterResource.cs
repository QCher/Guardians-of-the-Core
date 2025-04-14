using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class CharacterResource
{
    public string Id;
    [AssetReferenceUILabelRestriction("characters")]
    public AssetReferenceGameObject  Asset;
}