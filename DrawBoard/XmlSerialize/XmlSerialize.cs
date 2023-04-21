using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DrawBoard.XmlSerialize
{
    public class XmlSerialize
    {
        public static String Serialize<T>(T t)
        {
            using (StringWriter sw = new StringWriter())
            using (XmlWriter xw = XmlWriter.Create(sw, new XmlWriterSettings { Encoding = Encoding.UTF8 }))
            {
                new XmlSerializer(typeof(T)).Serialize(xw, t);
                return sw.GetStringBuilder().ToString();
            }
        }

        public static T Deserialize<T>(String s_xml)
        {
            using (XmlReader xw = XmlReader.Create(new StringReader(s_xml)))
                return (T)new XmlSerializer(typeof(T)).Deserialize(xw);
        }

        public static void Save<T>(T file, String path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, file);
            }
        }

        public static T Read<T>(String path, Type type)
        {
            // Create a new serializer
            XmlSerializer serializer = new XmlSerializer(type);

            // Create a StreamReader
            TextReader reader = new StreamReader(path);

            // Deserialize the file
            T file = (T)serializer.Deserialize(reader);

            // Close the reader
            reader.Close();

            // Return the object
            return file;
        }

    }
}