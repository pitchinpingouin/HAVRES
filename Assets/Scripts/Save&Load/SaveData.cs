using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;


[XmlRoot("Data")]
public class SaveData
{
    [XmlArray("Trees")]
    [XmlArrayItem("Tree")]
    public List<TreeData> Trees = new List<TreeData>();
    [XmlArray("Rocks")]
    [XmlArrayItem("Rock")]
    public List<RockData> Rocks = new List<RockData>();
    [XmlArray("Logs")]
    [XmlArrayItem("Log")]
    public List<WoodLogData> WoodLogs = new List<WoodLogData>();
    [XmlArray("Splashes")]
    [XmlArrayItem("Splash")]
    public List<FruitSplashData> Splashes = new List<FruitSplashData>();
}
