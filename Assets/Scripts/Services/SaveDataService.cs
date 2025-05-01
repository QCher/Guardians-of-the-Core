using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class SaveDataService
{
    public void Save<T>(T data, string fileName){
        var formatter = new BinaryFormatter();
        using var stream = File.Open(Application.persistentDataPath + $"/{fileName}.dat", FileMode.OpenOrCreate);
        formatter.Serialize(stream, data);
    }

    public T Load<T>(string fileName)
    {
        if (!File.Exists(Application.persistentDataPath + $"/{fileName}.dat")) return default;
        var formatter = new BinaryFormatter ();
        using var stream = File.Open(Application.persistentDataPath + $"/{fileName}.dat", FileMode.Open);
        var serializableSaveData = (T)formatter.Deserialize(stream);
        return serializableSaveData;
    }
#if UNITY_EDITOR
    [MenuItem("SaveDataService/Clear Data")]
    static void ClearData()
    {
        Debug.Log($"Clear Data at {Application.persistentDataPath}");
        var data = Directory.EnumerateFiles(Application.persistentDataPath, "*.dat", SearchOption.AllDirectories);
        foreach (var path in data)
        {
            File.Delete(path);
        }
    }
#endif
}
