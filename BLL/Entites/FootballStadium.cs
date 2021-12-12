using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL
{
    [Serializable]
    public sealed class FootballStadium : ISerializable, IInitializable, IChangeable, IDemonstrated, IFieldComparable
    {
        private int _numberSeats;
        private int _priceSeat;
        private StadiumName _nameStadion;

        public FootballStadium() { }

        public FootballStadium(int NumberSeats, int PriceSeat, StadiumName NameStadium)
        {

            _numberSeats = NumberSeats;
            _priceSeat = PriceSeat;
            _nameStadion = NameStadium;


        }

        private FootballStadium(SerializationInfo info, StreamingContext context)
        {
            _numberSeats = info.GetInt32("Number of seats");
            _priceSeat = info.GetInt32("Price of seats");
            _nameStadion = (StadiumName)info.GetValue("Name Stadium", typeof(StadiumName));


        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("Number of seats", _numberSeats);
            info.AddValue("Price of seats", _priceSeat);
            info.AddValue("Name Stadium", _nameStadion);
   


        }

        public void Initialize(FieldCollection initializer)
        {
            _numberSeats = initializer["Number of seats"];
            _priceSeat = initializer["Price of seats"];
            _nameStadion = initializer["Name Stadium"];
        }


        public string GetDemonstrationString()
        {
            return $"Name Stadium - {_nameStadion}\n" +
                $"Number of seats - {_numberSeats}\n" +
                $"Price of seats - {_priceSeat}\n";
        }
        void IChangeable.Change(FieldCollection parameters)
        {
            _numberSeats = parameters["Number of seats"];
            _priceSeat = parameters["Price of seats"];

        }

        bool IFieldComparable.IsMatch(FieldCollection fields)
        {
            return _nameStadion.ToString() == fields["Name Stadium"];
              
        }

    }
}
