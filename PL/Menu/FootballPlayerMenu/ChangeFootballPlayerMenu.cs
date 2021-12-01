
using BLL;
using System;

namespace PL
{
    class ChangeFootballPlayerMenu : InitializationMenu
    {
        private IFootBallService _service;
        private FieldCollection _fields;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is FootballPlayerChangeMenuInitArgs)
            {
                var args = (FootballPlayerChangeMenuInitArgs)initArgs;
                _service = args.service;
                _fields = args.fields;
            }
        }

        protected override void SetupViewQueue()
        {
            AddView("========== Change Football Player ==========");
            AddEnumView(typeof(Health));
            AddView("new status: ", true);
            AddView("new salary: ", true);
            AddView("new health: ", true);
        }

        protected override void OnInputFilled(string[] inputs)
        {
            var fieldCollection = new FieldCollection(2);

            fieldCollection.Add("Health", Enum.Parse<Health>(inputs[0]));
            fieldCollection.Add("Salary", inputs[1]);
            fieldCollection.Add("Status", new TimeSpan(Convert.ToInt32(inputs[2]), 0, 0));

            _service.Change(_fields, fieldCollection);
        }
    }
}
