using BLL;
using System;

namespace PL
{
    class DeleteStadium : InitializationMenu
    {
        private IService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            var args = initArgs as StadiumRegistryMenuInitArgs;

            if (args != null)
                _service = args.service;
        }

        protected override void SetupViewQueue()
        {
            AddView("========== Delete Game ==========");
            AddView("Name Stadium: ", true);
        }

        protected override void OnInputFilled(string[] parameters)
        {
            FieldCollection initializer = new FieldCollection(1);

            initializer.Add("Name Stadium", parameters[0].ToString());

            _service.Delete<FootballStadium>(initializer);
        }
    }
}
