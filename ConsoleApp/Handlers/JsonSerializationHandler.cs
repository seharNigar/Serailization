using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleApp.Handlers
{
    public class JsonSerializationHandler<T> where T : class
    {
        public JsonSerializationHandler()
        {

        }

        public string Serailize(List<T> temp)
        {
            string result = string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(temp, Formatting.Indented);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while serializaing data", ex);
            }

            return result;
        }

        public List<T> Deserialize(string data)
        {
            List<T> temp = null;

            try
            {
                temp = JsonConvert.DeserializeObject<List<T>>(data);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while Deserializaing data", ex);
            }

            return temp;
        }
    }
}
