using System;
using System.IO;

namespace DAL
{
    public class DataContext
    {
        private Formatter _formatter;

        public DataContext()
        {
            _formatter = new Formatter();
        }
        public void Serialize(string path, object data, bool append = true)
        {
            if (string.IsNullOrEmpty(path) || data == null)
                throw new ArgumentNullException();

            if (!append)
                File.Delete(path);

            using (Stream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                _formatter.Serialize(stream, data);
        }

        public object[] Deserialize(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException();

            using (Stream stream = File.Open(path, FileMode.Open))
                return _formatter.Deserialize(stream);
        }
    }
}