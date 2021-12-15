using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL
{
    [Serializable]
    public sealed class FootballGame : ISerializable, IInitializable, IChangeable, IDemonstrated, IFieldComparable
    {
        public DateTime _dateOfEvent;
        public PlaceGame _placeGame;
        public Teams _team1;
        public Teams _team2;
        public int _numberOfspectators;
        public string _resultGame;
        public int _countTeamOne;
        public int _countTeamTwo;
        public string _win = "Nobody";

        public IEnumerable<FootballPlayer> Players => players;

        public void AddOffer(FootballPlayer finded)
        {
            players.Add(finded);
        }

        public void DeleteOffer(FootballPlayer finded)
        {
            players.Remove(finded);
        }
        List<FootballPlayer> players = new List<FootballPlayer>();

        public DateTime DateOfEvent => _dateOfEvent;
        public string Win => _win;
 
        public FootballGame() { }                                                                                       

        public FootballGame(DateTime dateOfEvent, PlaceGame placeGame, int numberOfspectator, Teams team1, Teams team2)
        {
            _team1 = team1;
            _team2 = team2;
            _dateOfEvent = dateOfEvent;
            _placeGame = placeGame;
            _numberOfspectators = numberOfspectator;
   


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
            players = (List<FootballPlayer>)info.GetValue("offers", typeof(List<FootballPlayer>));

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
            info.AddValue("offers", players);


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
            string bebra = $"Team One - {_team1} = = = " +
                $"Team Two - {_team2}\n"
            + $"Date of Event: {_dateOfEvent}\n"
                + $"Place game: {_placeGame}\n"
                + $"Number of spectators: {_numberOfspectators}\n"
                + $"Result game: {_resultGame}\n"
                + $"Win: {_win}\n"
                + $"Players :  \n ";
            foreach (var item in players)
            {
                bebra += item._name + " ";
                bebra += item._surname + "\n";
     
            }
            return bebra;

        }
        public override bool Equals(object obj)
        {
            if (obj is FootballGame footballGame)
            {
                return this._numberOfspectators == footballGame._numberOfspectators && this._dateOfEvent == footballGame._dateOfEvent && this._placeGame == footballGame._placeGame;
            }
            return false;
        }
        public void Change(FieldCollection parameters)
        {
            _placeGame = parameters["Place game"];
            _numberOfspectators = parameters["Number of spectators"];
            _dateOfEvent = parameters["Date of Event"];
        }
        public bool IsMatch(FieldCollection fields)
        {
            return _dateOfEvent == fields["Date of Event"] || _placeGame == fields["Place game"]; 
        }}}
