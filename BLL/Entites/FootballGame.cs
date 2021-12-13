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
        private int _countTeamOne;
        private int _countTeamTwo;
        private string _win = "Nobody";


        public DateTime DateOfEvent => _dateOfEvent;
        public string ResultGame => _resultGame;
        public FootballGame() { }                                                                                       

        public FootballGame(DateTime dateOfEvent, PlaceGame placeGame, int numberOfspectator, string resultGame, Teams team1, Teams team2, int countTeamOne, int countTeamTwo, string win )
        {
            _team1 = team1;
            _team2 = team2;
            _dateOfEvent = dateOfEvent;
            _placeGame = placeGame;
            _numberOfspectators = numberOfspectator;
            _resultGame =  resultGame;
            _countTeamOne = countTeamOne;
            _win = win;


        }

        private FootballGame(SerializationInfo info, StreamingContext context)
        {
            _team1 = (Teams)info.GetValue("Team One", typeof(Teams));
            _team2 = (Teams)info.GetValue("Team Two", typeof(Teams));
            _dateOfEvent = (DateTime)info.GetValue("Date of Event", typeof(DateTime));
            _placeGame = (PlaceGame)info.GetValue("Place game", typeof(PlaceGame));
            _numberOfspectators = info.GetInt32("Number of spectators");
            _resultGame = info.GetString("Result game");
            _win = info.GetString("Win");

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("Date of Event", _dateOfEvent);
            info.AddValue("Place game", _placeGame);
            info.AddValue("Number of spectators", _numberOfspectators);
            info.AddValue("Result game", _resultGame);
            info.AddValue("Team One", _team1);
            info.AddValue("Team Two", _team2);
            info.AddValue("Win", _win);


        }


        public void Initialize(FieldCollection initializer)
        {
            _team1 = initializer["Team One"];
            _team2 = initializer["Team Two"];
            _dateOfEvent = initializer["Date of Event"];
            _placeGame = initializer["Place game"];
            _numberOfspectators = initializer["Number of spectators"];
            _countTeamOne = new Random().Next(0, 9);
            _countTeamTwo = new Random().Next(0, 9);
            if (_dateOfEvent < DateTime.Now)
            {
                _resultGame = $"{_countTeamOne} : {_countTeamTwo}";
                if (_countTeamOne > _countTeamTwo)
                {
                    _win = $"{_team1}";
                }
                if(_countTeamOne < _countTeamTwo)
                {
                    _win = $"{_team2}";
                }



            }
            else
            {
                _resultGame = "0 : 0";
            }
           


        }


        public string GetDemonstrationString()
        {
            return $"Team One - {_team1} = = = " +
                $"Team Two - {_team2}\n" 
            +$"Date of Event: {_dateOfEvent}\n"
                + $"Place game: {_placeGame}\n"
                + $"Number of spectators: {_numberOfspectators}\n"
                + $"Result game: {_resultGame}\n"
                + $"Win: {_win}\n"
                + $"Players : \n " 
                + $" ";

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
        public void MuchStatus(FootballGame result)
        {
           
           /*if (_win == null)
            {
                return _win;
            }*/
        }
        
    }
}
