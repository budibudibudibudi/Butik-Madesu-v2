using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class tempsavesystem
{
    const string savepath = "/saves";
    
    public static void save<T>(T obj,string key)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + savepath;
        Directory.CreateDirectory(path);
        FileStream stream = new FileStream(path + key, FileMode.Create);
        formatter.Serialize(stream, obj);
        stream.Close();
    }
    public static T load<T>(string key)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + savepath;
        T data = default;
        if (File.Exists(path + key))
        {
            FileStream stream = new FileStream(path + key, FileMode.Open);
            formatter.Deserialize(stream);
            stream.Close();

        }
        else
            Debug.Log("error, nothing save file");

        return data;

    }
    public static bool saveexist(string key)
    {
        string path = Application.persistentDataPath + savepath;
        return File.Exists(path + key);
    }
}
