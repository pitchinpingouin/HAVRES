using System.Xml;
using System.Xml.Serialization;

public class RockData
{
    [XmlAttribute]
    public long id;
    [XmlAttribute]
    public int RockNumber;

    public float X;
    public float Y;
    public float Z;
}
