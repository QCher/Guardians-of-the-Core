using UnityEditor;
using UnityEngine;

namespace Util.Editor
{
    [InitializeOnLoad]
    public class BuildWithScriptingDefines
    {
        static BuildWithScriptingDefines()
        {
            bool toBuild = SessionState.GetBool("BuildAddressables", false);
            SessionState.EraseBool("BuildAddressables");
            if (toBuild)
            {
                Debug.Log("Domain reload complete, building Addressables as requested");
                BuildAddressablesAndRevertDefines();
            }
        }

        [MenuItem("Build/Addressables with script define")]
        public static void BuildTest()
        {
#if !MYDEFINEHERE
            Debug.Log("Setting up SessionState to inform an Addressables build is requested on next Domain Reload");
            SessionState.SetBool("Build Addressable", true);
            string originalDefines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            string newDefines = string.IsNullOrEmpty(originalDefines) ? "MYDEFINEHERE" : originalDefines + ";MYDEFINEHERE";
            Debug.Log("Setting Scripting Defines, this will then start compiling and begin a domain reload of the Editor Scripts.");
            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, newDefines);
#endif
        }

        static void BuildAddressablesAndRevertDefines()
        {
#if MYDEFINEHERE
        Debug.Log("Correct scripting defines set for desired build");
        AddressableAssetSettings.BuildPlayerContent();
        string originalDefines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
        if (originalDefines.Contains(";MYDEFINEHERE"))
            originalDefines = originalDefines.Replace(";MYDEFINEHERE", "");
        else
            originalDefines = originalDefines.Replace("MYDEFINEHERE", "");
        PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, originalDefines);
        AssetDatabase.SaveAssets();
#endif
            EditorApplication.Exit(0);
        }
    }

}