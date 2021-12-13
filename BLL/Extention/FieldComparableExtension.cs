using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class FieldComparableExtension
    {
        public static object[] Delete(this IFieldComparable[] from, FieldCollection parameters)
        {
            List<object> newEntities = new List<object>();

            foreach (var entity in from)
            {
                if (entity.IsMatch(parameters) == false)
                    newEntities.Add(entity);
            }

            return newEntities.ToArray();
        }
    }
}
