using System;
using System.Collections.Generic;

namespace BLL
{
    public static class ArrayExtension
    {
        public static T[] To<T>(this object[] objects)
        {
            List<T> people = new List<T>(objects.Length);

            foreach (var obj in objects)
            {
                if (obj is T person)
                    people.Add(person);
            }

            return people.ToArray();
        }
    }
}
