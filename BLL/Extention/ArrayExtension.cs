using System.Collections;
using System.Collections.Generic;

namespace BLL
{
    public static class ArrayExtension
    {
        public static T[] ToArray<T>(this object[] objects) where T : class
        {
            List<T> people = new List<T>(objects.Length);

            foreach (var obj in objects)
            {
                T newPerson = obj as T;

                if (newPerson != null)
                    people.Add(newPerson);
            }

            return people.ToArray();
        }

        public static void Add<T>(this T[] array, T newElement)
        {
            T[] newArray = new T[array.Length + 1];
            array.CopyTo(newArray, 0);
            newArray[array.Length] = newElement;
            array = newArray;
        }
    }
}
