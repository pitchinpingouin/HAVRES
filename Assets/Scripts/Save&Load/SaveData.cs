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
}
