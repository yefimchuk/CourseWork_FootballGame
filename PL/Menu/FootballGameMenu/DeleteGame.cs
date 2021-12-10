using BLL;
using System;

namespace PL
{
    class DeleteGame : InitializationMenu
    {
        private IService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            var args = initArgs as GameRegistryMenuInitArgs;

            if (args != null)
                _service = args.service;
        }

        protected override void SetupViewQueue()
        {
            AddView("========== Delete Game ==========");
            AddView("Date of Event: ", true);
        }

        protected override void OnInputFilled(string[] parameters)
        {
            FieldCollection initializer = new FieldCollection(1);

            initializer.Add("Date of Event", DateTime.Parse(parameters[0])); 


            _service.Delete<FootballGame>(initializer);
        }
    }
}
