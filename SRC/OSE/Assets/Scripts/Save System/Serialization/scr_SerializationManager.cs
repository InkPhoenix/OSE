using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class scr_SerializationManager : MonoBehaviour
{
    public static bool Save(string saveName, object saveData)
    {
        BinaryFormatter formatter = GetBinaryFormatter();

        // Folder stucture
        if (!Directory.Exists(Application.persistentDataPath + "/Save Files/Controls"))
        {
            Directory.CreateDirectory((Application.persistentDataPath + "/Save Files/Controls"));
        }

        string path = Application.persistentDataPath + "/Save Files/Controls/" + saveName + ".sav";

        FileStream file = File.Create(path);
        formatter.Serialize(file, saveData);
        file.Close();

        return true;
    }

    public static object Load(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load file at {0}", path);
            file.Close();
            return null;
        }
    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        return formatter;
    }
}
