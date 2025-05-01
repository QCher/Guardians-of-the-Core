using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class SaveDataService
{
    private const string DefaultFileExtention = ".dat";
    public void Save<T>(T data, string fileName){
        try
        {
            var formatter = new BinaryFormatter();
            using var stream = File.Open(CreateDefaultFullPath(fileName), FileMode.OpenOrCreate);
            formatter.Serialize(stream, data);
        }
        catch (IOException e)
        {
            Debug.LogException(e);
        }
    }

    public bool TryLoad<T>(string fileName, out T data)
    {
        data = default;
        var path = CreateDefaultFullPath(fileName);
        if (!File.Exists(path)) return false;
        var formatter = new BinaryFormatter ();
        using var stream = File.Open(path, FileMode.Open);
        data = (T)formatter.Deserialize(stream);
        return true;
    }
    
    string CreateFileName(string fileName) => $"{fileName}{DefaultFileExtention}";
    string CreateDefaultFullPath(string fileName) => Path.Combine(Application.persistentDataPath, CreateFileName(fileName));
    
    
#if UNITY_EDITOR
    [MenuItem("SaveDataService/Clear Data")]
    static void ClearData()
    {
        Debug.Log($"Clear Data at {Application.persistentDataPath}");
        var defaultPath = Path.Combine(Application.persistentDataPath);
        var data = Directory.EnumerateFiles(defaultPath, "*.dat", SearchOption.AllDirectories);
        foreach (var path in data)
        {
            File.Delete(path);
        }
    }
#endif
}
