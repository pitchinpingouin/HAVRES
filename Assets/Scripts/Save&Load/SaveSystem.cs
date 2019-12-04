using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static SaveData Data;
    private static readonly string path = Path.Combine(Application.persistentDataPath, "saveData.xml");

    public static void Save()
    {
        var serializer = new XmlSerializer(typeof(SaveData));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, Data);
        }
    }

    public static SaveData Load()
    {
        var serializer = new XmlSerializer(typeof(SaveData));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            Data = serializer.Deserialize(stream) as SaveData;
            return Data;
        }
    }
}
