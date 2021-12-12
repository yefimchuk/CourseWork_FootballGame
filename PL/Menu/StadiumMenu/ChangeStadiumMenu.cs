
using BLL;
using System;

namespace PL
{
    class ChangeStadiumMenu : InitializationMenu
    {
        private IStadiumService _service;
        private FieldCollection _fields;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is StadiumChangeMenuInitArgs)
            {
                var args = (StadiumChangeMenuInitArgs)initArgs;
                _service = args.service;
                _fields = args.fields;
            }
        }

        protected override void SetupViewQueue()
        {
            AddView("========== Change Football Player ==========");

            AddView("new price of seats: ", true);
            AddView("new quantity of seats: ", true);

        }

        protected override void OnInputFilled(string[] inputs)
        {

            var fieldCollection = new FieldCollection(2);

            fieldCollection.Add("Number of seats", int.Parse(inputs[0]));
            fieldCollection.Add("Price of seats", int.Parse(inputs[1]));


            _service.ChangeStadium(_fields, fieldCollection);
        }
    }
}
