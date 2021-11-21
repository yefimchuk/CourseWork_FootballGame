using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAL
{
    class Formatter
    {
        public void Serialize(Stream stream, object data)
        {
            ISet<object> serialized = new HashSet<object>();

            if (new StreamReader(stream).ReadToEnd().Length > 0)
            {
                stream.Position = 0;
                object[] deserialized = Deserialize(stream);

                foreach (var item in deserialized)
                    serialized.Add(item);
            }

            stream.Position = 0;

            if (data is IEnumerable)
                foreach (var item in (IEnumerable)data)
                    serialized.Add(item);
            else
                serialized.Add(data);

            IFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, serialized.ToArray());
        }

        public object[] Deserialize(Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();

            return (object[])formatter.Deserialize(stream);
        }
    }
}