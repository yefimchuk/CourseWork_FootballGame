using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public struct FieldInfo
    {
        public readonly string name;
        public readonly dynamic value;

        public FieldInfo(string name, dynamic value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
