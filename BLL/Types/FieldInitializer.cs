using System.Collections.Generic;

namespace BLL
{
    public class FieldInitializer
    {
        private List<FieldInfo> _fields;

        public FieldInitializer(int initCapacity) => _fields = new List<FieldInfo>(4);

        public dynamic this[string name] => _fields.Find(fi => fi.name == name).value;

        public void Add(string name, dynamic value) => _fields.Add(new FieldInfo(name, value));
    }
}
