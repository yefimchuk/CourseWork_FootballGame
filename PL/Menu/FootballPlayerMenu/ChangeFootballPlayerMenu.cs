
using BLL;
using System;

namespace PL
{
    class ChangeFootballPlayerMenu : InitializationMenu
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
            AddView("new name: ", true);
            AddView("new surname: ", true);
            AddEnumView(typeof(Status));
            AddView("new status: ", true);
            AddView("new salary: ", true);
            AddEnumView(typeof(Health));
            AddView("new health: ", true);
            AddView("new born: ", true);
        }

        protected override void OnInputFilled(string[] inputs)
        {
          
            var fieldCollection = new FieldCollection(6);
            fieldCollection.Add("Name", inputs[0]);
            fieldCollection.Add("Surname", inputs[1]);
            fieldCollection.Add("Status", Enum.Parse<Status>(inputs[2]));
            fieldCollection.Add("Salary", inputs[3]);
            fieldCollection.Add("Health", Enum.Parse<Health>(inputs[4]));
            fieldCollection.Add("Born", DateTime.Parse(inputs[5]));
            Registry.GetService<PlayerSevice>().Change(_lastFields, fieldCollection);
        }
    }
}
