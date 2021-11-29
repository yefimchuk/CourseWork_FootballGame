using BLL;
using System;

namespace PL
{
    public class AddFootballPlayer : InitializationMenu
    {
        private IFootBallService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is DoctorRegistryMenuInitArgs)
            {
                var args = (DoctorRegistryMenuInitArgs)initArgs;
                _service = args.service;
            }
        }

        protected override void SetupViewQueue()
        {
            AddView("========== Add ==========");
            AddView("Name: ", true);
            AddView("Surname: ", true);
            AddView("Born: ", true);
            AddView("Status( 0 - perfect, 1 - good, 2 - damaged, 3 - tired, 4 - cantPlay): ", true);
            AddView("Health (0 - sick, 1 - healthy): ", true);
            AddView("Salary: ", true);
        }

        protected override void OnInputFilled(string[] inputs)
        {
            FieldCollection parameters = new FieldCollection(6);

            parameters.Add("Name", inputs[0]);
            parameters.Add("Surname", inputs[1]);
            parameters.Add("Born", DateTime.Parse(inputs[2]));
            parameters.Add("Status", Enum.Parse<Status>(inputs[3]));
            parameters.Add("Health", Enum.Parse<Health>(inputs[4]));
            parameters.Add("Salary", inputs[5]);
            _service.Add<FootballPlayer>(parameters);
        }
    }
}
