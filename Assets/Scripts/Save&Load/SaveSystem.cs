using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static SaveData Data;
    private static readonly string path = "/sdcard/Havres/saveData.xml"; //Path.Combine(Application.persistentDataPath, "/saveData.xml");

    public static void Save()
    {
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            serializer.Serialize(writer, Data);
        }
    }

    public static SaveData Load()
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                var serializer = new XmlSerializer(typeof(SaveData));
                Data = serializer.Deserialize(reader) as SaveData;
            }
        }
        else
        {
            Data = new SaveData();
            Save(); // just to create a new empty save file
        }

        return Data;
    }
}
