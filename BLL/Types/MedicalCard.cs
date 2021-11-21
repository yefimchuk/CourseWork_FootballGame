using System;
using System.Runtime.Serialization;

namespace BLL
{
    [Serializable]
    public sealed class MedicalCard : ISerializable
    {
        private string _name;
        private string _surname;
        private int _age;

        private MedicalCard(SerializationInfo info, StreamingContext context)
        {
            _name = info.GetString("Name");
            _surname = info.GetString("Surname");
            _age = info.GetInt32("Age");
        }

        public MedicalCard(string name, string surname, int age)
        {
            _name = name;
            _surname = surname;
            _age = age;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", _name);
            info.AddValue("Surname", _surname);
            info.AddValue("Age", _age);
        }
    }
}
