using System.Xml;
using System.Xml.Serialization;

public class TreeData
{
    [XmlAttribute("state")]
    public int State;

    public float X;
    public float Y;
    public float Z;
}
