#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

public class ContentBuilder
{
    private const string RemoteSettingAAPath = "Assets/AddressableAssetsData/AddressableAssetSettings[Remote].asset";
    private const string BuilderAssetPath = "Assets/AddressableAssetsData/DataBuilders/ContentBuildScript.asset";
    [MenuItem("Addressables/Build Content")]
    static void BuildContent()
    {
        if (!SetupAASettings(RemoteSettingAAPath))
        {
            Debug.LogError($"Failed to build content file on {nameof(SetupAASettings)} stage");
            return;
        }

        if (!SetupProfile())
        {
            Debug.LogError($"Failed to build content file on {nameof(SetupProfile)} stage");
            return;
        }

        if (!SetupBuilder(BuilderAssetPath))
        {
            Debug.LogError($"Failed to build content file on {nameof(SetupBuilder)} stage");
            return;
        }
        
        AddressableAssetSettings.BuildPlayerContent(out var result);
        var success = string.IsNullOrEmpty(result.Error);
        if (!success)
        {
            Debug.LogError("Addressable build error encountered: " + result.Error);
        }
        else
        {
            Debug.Log("<color=green>Addressable build succeeded</color>");
        }
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

    static bool SetupProfile(string profileName = "Remote")
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

    static bool SetupBuilder(string assetPath)
    {
        var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath) as IDataBuilder;
        if (asset == null)
        {
            Debug.LogError($"Asset at path: {assetPath} not found.");
            return false;
        }
        
        int index = AddressableAssetSettingsDefaultObject.Settings.DataBuilders.IndexOf((ScriptableObject)asset);

        if (index > 0)
            AddressableAssetSettingsDefaultObject.Settings.ActivePlayerDataBuilderIndex = index;
        else
        {
            Debug.LogWarning($"{asset} must be added to the " +
                             $"DataBuilders list before it can be made " +
                             $"active. Using last run builder instead.");
            return false;
        }
        
        return true;
    }
    
    
    /// <summary>
    /// Example:
    /// D:\Unity\2020.3.0f1\Editor\Unity.exe -quit -batchMode -projectPath . -executeMethod BatchBuild.ChangeSettings -defines=FOO;BAR -buildTarget Android
    ///D:\Unity\2020.3.0f1\Editor\Unity.exe -quit -batchMode -projectPath . -executeMethod BatchBuild.BuildContentAndPlayer -buildTarget Android
    /// </summary>
    public static void ChangeSettings()
    {
        string defines = "";
        string[] args = Environment.GetCommandLineArgs();

        foreach (var arg in args)
            if (arg.StartsWith("-defines=", System.StringComparison.CurrentCulture))
                defines = arg.Substring(("-defines=".Length));

        var buildSettings = EditorUserBuildSettings.selectedBuildTargetGroup;
        PlayerSettings.SetScriptingDefineSymbolsForGroup(buildSettings, defines);
    }
}

#endif