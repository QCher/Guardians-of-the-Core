using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ContentBuilder
{
    [MenuItem("Addressables/Build Content")]
    static void BuildContent()
    {
       AddressableAssetSettings.BuildPlayerContent(out var result);
       Debug.Log(result);
    }
}
