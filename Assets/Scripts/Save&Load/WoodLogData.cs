using System.Xml;
using System.Xml.Serialization;

public class WoodLogData
{
    [XmlAttribute]
    public long id;

    public float X;
    public float Y;
    public float Z;
}
