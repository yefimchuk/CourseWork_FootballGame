using BLL;
using System;

namespace PL
{
    public class AddGamenMenu : InitializationMenu
    {
        private IGameService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is GameRegistryMenuInitArgs)
            {
                var args = (GameRegistryMenuInitArgs)initArgs;
                _service = args.service;
            }
        }

        protected override void SetupViewQueue()
        {

            AddView("========== Add ==========");
            AddEnumView(typeof(Teams)); 
            AddView("\nSelect the first team: ", true);
            AddEnumView(typeof(Teams));
            AddView("\nSelect the second team: ", true);
            AddView("Date of Event: ", true);
            AddEnumView(typeof(PlaceGame));
            AddView("\nPlaceGame", true);
            AddView("Number of spectators: ", true);
      
 
        }

        protected override void OnInputFilled(string[] inputs)
        {
            FieldCollection parameters = new FieldCollection(5);
            parameters.Add("Team 1", Enum.Parse<Teams>(inputs[0]));
            parameters.Add("Team 2", Enum.Parse<Teams>(inputs[1]));
            parameters.Add("Date of Event", DateTime.Parse(inputs[2]));
            parameters.Add("Place game", Enum.Parse<PlaceGame>(inputs[3]));
            parameters.Add("Number of spectators", int.Parse(inputs[4]));      
            _service.Add<FootballGame>(parameters);
        }
    }
}
