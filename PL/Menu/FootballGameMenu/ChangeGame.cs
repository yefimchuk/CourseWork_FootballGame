
using BLL;
using System;

namespace PL
{
    class ChangeGame : InitializationMenu
    {
        private FieldCollection _lastFields;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is InputParametersInitArgs args)
                _lastFields = args.fields[0];
        }

        protected override void SetupViewQueue()
        {
            AddView("========== Change Football Player ==========");
            AddEnumView(typeof(PlaceGame));
            AddView("New place: ", true);
            AddView("New date of event: ", true);
            AddView("New number of spectators: ", true);

        }

        protected override void OnInputFilled(string[] inputs)
        {

            var fieldCollection = new FieldCollection(4);
            fieldCollection.Add("Place game", Enum.Parse<PlaceGame>(inputs[0]));
            fieldCollection.Add("Date of Event", DateTime.Parse(inputs[1]));
            fieldCollection.Add("Number of spectators", int.Parse(inputs[2]));
            Registry.GetService<GameService>().Change(_lastFields, fieldCollection);
        }
    }
}
