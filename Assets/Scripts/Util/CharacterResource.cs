using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class CharacterResource
{
    public string Id;
    public AssetReferenceT<GameObject>  Asset;
}