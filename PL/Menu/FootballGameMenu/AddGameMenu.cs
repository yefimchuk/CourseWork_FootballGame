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

            if (initArgs is PatientRegistryMenuInitArgs)
            {
                var args = (PatientRegistryMenuInitArgs)initArgs;
                _service = args.service;
            }
        }

        protected override void SetupViewQueue()
        {

            AddView("========== Add ==========");
            AddView("Date of Event: ", true);
            AddView("Status(0 - Kiyv, 1 - Moscow, 2 - Lisbon, 3 - Athens, 4 - Warshava, 5 - Tokyo  ", true);
            AddView("Number of spectators: ", true);
      
 
        }

        protected override void OnInputFilled(string[] inputs)
        {
            FieldCollection parameters = new FieldCollection(3);

            parameters.Add("Date of Event", DateTime.Parse(inputs[0]));
            parameters.Add("Place game", Enum.Parse<PlaceGame>(inputs[1]));
            parameters.Add("Number of spectators", int.Parse(inputs[2]));      
            _service.Add<FootballGame>(parameters);
        }
    }
}
