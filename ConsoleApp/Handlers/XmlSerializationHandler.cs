using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp.Handlers
{
    public class XmlSerializationHandler<T> where T : class
    {
        private readonly string _path;
        private readonly XmlSerializer xmlSerializer;
        public XmlSerializationHandler(string path)
        {
            _path = path;
            xmlSerializer = new XmlSerializer(typeof(List<T>));
        }

        public void Serialize(List<T> temp)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(_path);
                xmlSerializer.Serialize(streamWriter, temp);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while serialization", ex);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Dispose();
                }
            }
        }

        public List<T> Deserialize()
        {
            List<T> temp = null;
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(_path);
                temp = xmlSerializer.Deserialize(streamReader) as List<T>;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while serialization", ex);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Dispose();
                }
            }

            return temp;
        }
    }
}
