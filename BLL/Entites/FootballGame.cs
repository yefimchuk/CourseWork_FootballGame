using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL
{
    [Serializable]
    public sealed class FootballGame : ISerializable, IInitializable, IChangeable, IDemonstrated
    {
        private DateTime _dateOfEvent;
        private PlaceGame _placeGame;
        private int _numberOfspectators;
        private string _resultGame;


        public FootballGame() { }                                                                                       

        public FootballGame(DateTime dateOfEvent, PlaceGame placeGame, int numberOfspectator, string resultGame)
        {
            _dateOfEvent = dateOfEvent;
            _placeGame = placeGame;
            _numberOfspectators = numberOfspectator;
            _resultGame =  resultGame;
    
        }

        private FootballGame(SerializationInfo info, StreamingContext context)
        {
            _dateOfEvent = info.GetDateTime("Date of Event");
            _placeGame = (PlaceGame)info.GetValue("Place game", typeof(PlaceGame));
            _numberOfspectators = info.GetInt32("Number of spectators");
            _resultGame = info.GetString("Result game");

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("Date of Event", _dateOfEvent);
            info.AddValue("Place game", _placeGame);
            info.AddValue("Number of spectators", _numberOfspectators);
            info.AddValue("Result game", _resultGame);
            

        }

        public void Initialize(FieldCollection initializer)
        {
            _dateOfEvent = initializer["Date of Event"];
            _placeGame = initializer["Place game"];
            _numberOfspectators = initializer["Number of spectators"];
            _resultGame = initializer["Result game"];
   


        }


        public string GetDemonstrationString()
        {
            return $"Date of Event: {_dateOfEvent}\n"
                + $"Place game: {_placeGame}\n"
                + $"Number of spectators: {_numberOfspectators}\n"
                + $"Result game: {_resultGame}\n";

        }
        void IChangeable.Change(FieldCollection parameters)
        {
            _placeGame = parameters["Place game"];
            _numberOfspectators = parameters["Number of spectators"];
            _dateOfEvent = parameters["Date of Event"];
        }
/*        bool IFieldComparable.IsMatch(FieldCollection fields)
        {
            return _name == fields["Name"]
                && _surname == fields["Surname"];
        }*/
    }
}
