using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL
{
    [Serializable]
    public sealed class FootballGame : ISerializable, IInitializable, IChangeable, IDemonstrated, IFieldComparable
    {
        private DateTime _dateOfEvent;
        private PlaceGame _placeGame;
        private Teams _team1;
        private Teams _team2;
        private int _numberOfspectators;
        private string _resultGame;

        public  DateTime DateOfEvent => _dateOfEvent;
        public FootballGame() { }                                                                                       

        public FootballGame(DateTime dateOfEvent, PlaceGame placeGame, int numberOfspectator, string resultGame, Teams team1, Teams team2)
        {
            _team1 = team1;
            _team2 = team2;
            _dateOfEvent = dateOfEvent;
            _placeGame = placeGame;
            _numberOfspectators = numberOfspectator;
            _resultGame =  resultGame;



        }

        private FootballGame(SerializationInfo info, StreamingContext context)
        {
            _team1 = (Teams)info.GetValue("Team One", typeof(Teams));
            _team2 = (Teams)info.GetValue("Team Two", typeof(Teams));
            _dateOfEvent = (DateTime)info.GetValue("Date of Event", typeof(DateTime));
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
            info.AddValue("Team One", _team1);
            info.AddValue("Team Two", _team2);


        }

        public void Initialize(FieldCollection initializer)
        {
            _team1 = initializer["Team 1"];
            _team2 = initializer["Team 2"];
            _dateOfEvent = initializer["Date of Event"];
            _placeGame = initializer["Place game"];
            _numberOfspectators = initializer["Number of spectators"];
            if (_dateOfEvent < DateTime.Now)
            {
                _resultGame = $"{new Random().Next(0, 9)} : {new Random().Next(0, 9)}";
            }
            else
            {
                _resultGame = "0 : 0";
            }
           


        }


        public string GetDemonstrationString()
        {
            return $"Team 1 - {_team1} = = = " +
                $"Team 2 - {_team2}\n" 
            +$"Date of Event: {_dateOfEvent}\n"
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
        bool IFieldComparable.IsMatch(FieldCollection fields)
        {
            return _dateOfEvent == DateTime.Parse(fields["Date of Event"]);
              
        }
        public void MuchStatus()
        {

        }
    }
}
