using BLL;
using System;

namespace PL
{
    public class AddStadiumMenu : InitializationMenu
    {
        private IStadiumService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is StadiumRegistryMenuInitArgs)
            {
                var args = (StadiumRegistryMenuInitArgs)initArgs;
                _service = args.service;
            }
        }

        protected override void SetupViewQueue()
        {

            AddView("========== Add ==========");
            AddEnumView(typeof(StadiumName));
            AddView("Select name stadium: ", true);

            AddView("Select price of seats ", true);

            AddView("Select number of spectators: ", true);


        }

  
        protected override void OnInputFilled(string[] inputs)
        {
            FieldCollection parameters = new FieldCollection(3);
            parameters.Add("Name Stadium", Enum.Parse<StadiumName>(inputs[0]));
            parameters.Add("Price of seats", int.Parse(inputs[1]));
            parameters.Add("Number of seats", int.Parse(inputs[2]));
            _service.Add<FootballStadium>(parameters);
        }
    }
}
