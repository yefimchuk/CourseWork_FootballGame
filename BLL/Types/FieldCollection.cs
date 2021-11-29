using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FieldCollection
    {
        private List<FieldInfo> _fields;

        public FieldCollection(int initCapacity) => _fields = new List<FieldInfo>(initCapacity);

        public dynamic this[string name] => _fields.Find(fi => fi.name == name).value;

        public void Add(string name, dynamic value) => _fields.Add(new FieldInfo(name, value));
    }
}
