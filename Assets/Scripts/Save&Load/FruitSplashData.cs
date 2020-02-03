using System.Xml;
using System.Xml.Serialization;

public class FruitSplashData
{
    [XmlAttribute]
    public int ttl; // time to live

    public float X;
    public float Y;
    public float Z;

    public float RotX;
    public float RotY;
    public float RotZ;
}
