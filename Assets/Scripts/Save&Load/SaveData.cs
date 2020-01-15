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
}
