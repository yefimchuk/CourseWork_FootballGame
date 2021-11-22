using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL
{
    [Serializable]
    public sealed class FootballPlayer: ISerializable, IInitializable
    {
        private string _name;
        private string _surname;
        private DateTime _born;
        private  Status _status;
        private Health _health;
        private string _salary;
   

        public FootballPlayer() { }

        public FootballPlayer(string name, string surname, DateTime born, Status status, Health health, string salary) 
        {
            _name = name;
            _surname = surname;
            _born = born;
            _status = status;
            _health = health;
            _salary = salary;
        }

        private FootballPlayer(SerializationInfo info, StreamingContext context)
        {
            _name = info.GetString("Name");
            _surname = info.GetString("Surname");
            _born = (DateTime)info.GetValue("Born", typeof(DateTime));
            _status = (Status)info.GetValue("Status", typeof(Status));
            _health = (Health) info.GetValue("Health", typeof(Health));
            _salary = info.GetString("Salary");

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("Name", _name);
            info.AddValue("Surname", _surname);
            info.AddValue("Born", _born);
            info.AddValue("Status", _status);
            info.AddValue("Health", _health);
            info.AddValue("Salary", _salary);

        }

        public void Initialize(FieldInitializer initializer)
        {
            _salary = initializer["Salary"];
            _name = initializer["Name"];
            _surname = initializer["Surname"];
            _status = initializer["Status"];


        }
           
    }
}
