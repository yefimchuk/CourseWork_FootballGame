using BLL;
using System;

namespace PL
{
    class DeleteFootballPlayer : InitializationMenu
    {
        private IService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            var args = initArgs as DoctorRegistryMenuInitArgs;

            if (args != null)
                _service = args.service;
        }

        protected override void SetupViewQueue()
        {
            AddView("========== Delete Doctor ==========");
            AddView("Name: ", true);
            AddView("Surname: ", true);
        }

        protected override void OnInputFilled(string[] parameters)
        {
            FieldCollection initializer = new FieldCollection(1);

            initializer.Add("Name", parameters[0]);
            initializer.Add("Surname", parameters[1]);

            _service.Delete<FootballPlayer>(initializer);
        }
    }
}
