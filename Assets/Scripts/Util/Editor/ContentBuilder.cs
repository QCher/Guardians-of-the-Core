using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ContentBuilder
{
    private const string RemoteSettingAAPath = "Assets/AddressableAssetsData/AddressableAssetSettings[Remote].asset";
    [MenuItem("Addressables/Build Content")]
    static void BuildContent()
    {
        if (!SetupAASettings(RemoteSettingAAPath))
        {
            Debug.LogError($"Failed to build content file on {nameof(SetupAASettings)} stage");
            return;
        }

        if (!SetProfile())
        {
            Debug.LogError($"Failed to build content file on {nameof(SetProfile)} stage");
            return;
        }
        
        AddressableAssetSettings.BuildPlayerContent(out var result);
        Debug.Log(result);
    }


    static bool SetupAASettings(string assetPath)
    {
        var settings = AssetDatabase.LoadAssetAtPath<AddressableAssetSettings>(assetPath);
        if (settings == null)
        {
            Debug.LogError($"Asset at path: {assetPath} not found.");
            return false;
        }

        AddressableAssetSettingsDefaultObject.Settings = settings;
        return true;
    }

    static bool SetProfile(string profileName = "Remote")
    {
        var profileId = AddressableAssetSettingsDefaultObject.Settings.profileSettings.GetProfileId(profileName);
        if (string.IsNullOrEmpty(profileId))
        {
            Debug.LogError($"Profile named:{profileName} not found.");
            return false;
        }
        AddressableAssetSettingsDefaultObject.Settings.activeProfileId = profileId;
        return true;
    }
}
